//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Management;
//using System.Net.NetworkInformation;
//using System.Net.Sockets;
//using System.Net;
//using System.Security.Cryptography.Pkcs;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using SnmpSharpNet;


//namespace equipment_accounting_system.Classes
//{
//    internal class network_Scanner
//    {
//        private static readonly Dictionary<string, string> _ouiDictionary = new Dictionary<string, string>();

//        public async Task<List<(string IpAddress, string HostName, string Status)>> ScanNetworkRangeAsync(IPAddress startIp, IPAddress endIp, CancellationToken cancellationToken)
//        {
//            var pingSender = new Ping();
//            var tasks = new List<Task<(string IpAddress, string HostName, string Status)>>();
//            byte[] startIpBytes = startIp.GetAddressBytes();
//            byte[] endIpBytes = endIp.GetAddressBytes();


//            for (int i = startIpBytes[3]; i <= endIpBytes[3]; i++)
//            {
//                cancellationToken.ThrowIfCancellationRequested();
//                var buffer = (byte[])startIpBytes.Clone();
//                buffer[3] = (byte)i;
//                var ipToPing = new IPAddress(buffer);
//                tasks.Add(PingAndResolveAsync(pingSender, ipToPing, cancellationToken));
//            }

//            var results = await Task.WhenAll(tasks);
//            return new List<(string IpAddress, string HostName, string Status)>(results);
//        }
//        private async Task<(string IpAddress, string HostName, string Status)> PingAndResolveAsync(Ping pingSender, IPAddress ipToPing, CancellationToken cancellationToken)
//        {



//            using (var localPingSender = new Ping())
//            {

//                var reply = await localPingSender.SendPingAsync(ipToPing, 250);
//                if (cancellationToken.IsCancellationRequested)
//                {

//                    return (ipToPing.ToString(), "", "Canceled");
//                }

//                if (reply.Status == IPStatus.Success)
//                {
//                    string hostName = "Не виявлено";
//                    try
//                    {
//                        var hostEntry = await Dns.GetHostEntryAsync(ipToPing);
//                        hostName = hostEntry.HostName;
//                    }
//                    catch
//                    {

//                    }
//                    return (ipToPing.ToString(), hostName, "Up");
//                }
//            }

//            return (ipToPing.ToString(), "", "Down");
//        }
//        public (IPAddress, IPAddress) GetLocalIpRange()
//        {
//            var netInterface = NetworkInterface.GetAllNetworkInterfaces()
//                .FirstOrDefault(n => (n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
//                                     n.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
//                                     n.OperationalStatus == OperationalStatus.Up);

//            if (netInterface == null)
//                throw new InvalidOperationException("No network adapters with an IPv4 address in the system!");

//            var ipInfo = netInterface.GetIPProperties().UnicastAddresses
//                .FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);

//            if (ipInfo == null)
//                throw new InvalidOperationException("No IPv4 address found.");

//            var ipAddress = ipInfo.Address;
//            var ipMask = ipInfo.IPv4Mask;

//            var networkAddress = GetNetworkAddress(ipAddress, ipMask);
//            var broadcastAddress = GetBroadcastAddress(ipAddress, ipMask);
//            return (networkAddress, broadcastAddress);
//        }
//        private IPAddress GetNetworkAddress(IPAddress address, IPAddress mask)
//        {
//            byte[] ipAddressBytes = address.GetAddressBytes();
//            byte[] subnetMaskBytes = mask.GetAddressBytes();
//            byte[] broadcastAddress = new byte[ipAddressBytes.Length];
//            for (int i = 0; i < broadcastAddress.Length; i++)
//            {
//                broadcastAddress[i] = (byte)(ipAddressBytes[i] & subnetMaskBytes[i]);
//            }
//            return new IPAddress(broadcastAddress);
//        }
//        private IPAddress GetBroadcastAddress(IPAddress address, IPAddress mask)
//        {
//            byte[] ipAddressBytes = address.GetAddressBytes();
//            byte[] subnetMaskBytes = mask.GetAddressBytes();
//            byte[] broadcastAddress = new byte[ipAddressBytes.Length];
//            for (int i = 0; i < broadcastAddress.Length; i++)
//            {
//                broadcastAddress[i] = (byte)(ipAddressBytes[i] | (~subnetMaskBytes[i]));
//            }
//            return new IPAddress(broadcastAddress);
//        }
//        public string GetMacAddress(string ipAddress)
//        {
//            string macAddress = string.Empty;
//            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
//            pProcess.StartInfo.FileName = "arp";
//            pProcess.StartInfo.Arguments = "-a " + ipAddress;
//            pProcess.StartInfo.UseShellExecute = false;
//            pProcess.StartInfo.RedirectStandardOutput = true;
//            pProcess.StartInfo.CreateNoWindow = true;
//            pProcess.Start();
//            string strOutput = pProcess.StandardOutput.ReadToEnd();
//            pProcess.WaitForExit();

//            string[] substrings = strOutput.Split('-');
//            if (substrings.Length >= 8)
//            {
//                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
//                         + "-" + substrings[4] + "-" + substrings[5] + "-"
//                         + substrings[6] + "-" + substrings[7] + "-"
//                         + substrings[8].Substring(0, 2);
//                return macAddress;
//            }

//            return macAddress;
//        }
//        public async Task<string> GetDeviceType(string ipAddress)
//        {
//            string deviceType = "Unknown";


//            if (await IsPortOpenAsync(ipAddress, new[] { 135, 139, 445 }))
//            {
//                deviceType = "Windows PC";
//            }

//            else if (await IsPortOpenAsync(ipAddress, new[] { 22 }))
//            {
//                deviceType = "UNIX/Linux PC";
//            }

//            else if (await IsPortOpenAsync(ipAddress, new[] { 80, 443 }))
//            {
//                deviceType = "Router/Ap";
//            }

//            else if (await IsPortOpenAsync(ipAddress, new[] { 515, 631, 9100 }))
//            {
//                deviceType = "Printer";
//            }

//            else if (await IsPortOpenAsync(ipAddress, new[] { 2049 }))
//            {
//                deviceType = "Network Storage";
//            }

//            return deviceType;
//        }
//        public async Task<bool> IsPortOpenAsync(string ipAddress, int[] ports)
//        {
//            var tasks = ports.Select(async port =>
//            {
//                using (var client = new TcpClient())
//                {
//                    try
//                    {
//                        var task = client.ConnectAsync(ipAddress, port);
//                        return await Task.WhenAny(task, Task.Delay(500)) == task && client.Connected;
//                    }
//                    catch
//                    {
//                        return false;
//                    }
//                }
//            });

//            var results = await Task.WhenAll(tasks);
//            return results.Any(r => r);
//        }
//        public void LoadOuiDatabase(string path)
//        {
//            string pattern = @"(?<oui>^[A-F0-9]{6})\s+\(base 16\)\s+(?<vendor>.+)";
//            var regex = new Regex(pattern, RegexOptions.Multiline);

//            var fileContent = File.ReadAllText(path);

//            var matches = regex.Matches(fileContent);

//            foreach (Match match in matches)
//            {
//                if (match.Success)
//                {
//                    var oui = match.Groups["oui"].Value;
//                    var vendor = match.Groups["vendor"].Value.Trim();

//                    if (!_ouiDictionary.ContainsKey(oui))
//                    {
//                        _ouiDictionary[oui] = vendor;
//                    }
//                }
//            }
//        }
//        public string GetManufacturerByMac(string macAddress)
//        {
//            var cleanedMac = macAddress.Replace(":", "").Replace("-", "").ToUpper();

//            return cleanedMac.Length >= 6 && _ouiDictionary.TryGetValue(cleanedMac.Substring(0, 6), out var vendor)
//                ? vendor
//                : "Не визначено";
//        }
//        public string GetWindowsOperatingSystemInfo(string ipAddress)
//        {
//            try
//            {
//                var username = ConfigurationManager.AppSettings["WMIUsername"];
//                var password = ConfigurationManager.AppSettings["WMIPassword"];

//                var options = new ConnectionOptions
//                {
//                    Impersonation = ImpersonationLevel.Impersonate,
//                    Username = username,
//                    Password = password
//                };
//                var scope = new ManagementScope($"\\\\{ipAddress}\\root\\cimv2", options);
//                scope.Connect();

//                var query = new ObjectQuery("SELECT Caption FROM Win32_OperatingSystem");
//                var searcher = new ManagementObjectSearcher(scope, query);

//                foreach (ManagementObject mo in searcher.Get())
//                {
//                    return mo["Caption"].ToString();
//                }
//            }
//            catch (Exception ex)
//            {
//                return $"Unable to retrieve OS info: {ex.Message}";
//            }

//            return "Unknown";
//        }
//        public string GetWindowsMachineName(string ipAddress)
//        {
//            try
//            {
//                var username = ConfigurationManager.AppSettings["WMIUsername"];
//                var password = ConfigurationManager.AppSettings["WMIPassword"];

//                var options = new ConnectionOptions
//                {
//                    Impersonation = ImpersonationLevel.Impersonate,
//                    Username = username,
//                    Password = password
//                };
//                var scope = new ManagementScope($"\\\\{ipAddress}\\root\\cimv2", options);
//                scope.Connect();

//                var query = new ObjectQuery("SELECT Name FROM Win32_ComputerSystem");
//                var searcher = new ManagementObjectSearcher(scope, query);

//                foreach (ManagementObject mo in searcher.Get())
//                {
//                    return mo["Name"].ToString();
//                }
//            }
//            catch (Exception ex)
//            {
//                return $"Unable to retrieve Machine Name: {ex.Message}";
//            }

//            return "Unknown";
//        }
//        public string GetSNMPData(string ipAddress, string oid)
//        {
//            try
//            {
//                var target = new UdpTarget(IPAddress.Parse(ipAddress), 161, 2000, 1);
//                var community = new OctetString("public");
//                var pdu = new Pdu(PduType.Get);
//                pdu.VbList.Add(oid);
//                var request = new AgentParameters(community)
//                {
//                    Version = SnmpVersion.Ver2
//                };

//                var response = target.Request(pdu, request);
//                if (response != null && response.Pdu.ErrorStatus == 0)
//                {
//                    return response.Pdu.VbList[0].Value.ToString();
//                }
//                return "No data received";
//            }
//            catch (Exception ex)
//            {
//                return $"SNMP Error: {ex.Message}";
//            }
//        }

//        public string GetSystemDescription(string ipAddress)
//        {
//            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.1.0");
//        }

//        public string GetSystemName(string ipAddress)
//        {
//            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.5.0");
//        }

//        public string GetSystemUptime(string ipAddress)
//        {
//            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.3.0");
//        }

//        public string GetSystemContact(string ipAddress)
//        {
//            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.4.0");
//        }

//        public string GetSystemLocation(string ipAddress)
//        {
//            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.6.0");
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using SnmpSharpNet;
using System.Diagnostics;
using Renci.SshNet;

namespace equipment_accounting_system.Classes
{
    internal class network_Scanner
    {
        private static readonly Dictionary<string, string> _ouiDictionary = new Dictionary<string, string>();

        public async Task<List<(string IpAddress, string HostName, string Status)>> ScanNetworkRangeAsync(IPAddress startIp, IPAddress endIp, CancellationToken cancellationToken)
        {
            var pingSender = new Ping();
            var tasks = new List<Task<(string IpAddress, string HostName, string Status)>>();

            byte[] startIpBytes = startIp.GetAddressBytes();
            byte[] endIpBytes = endIp.GetAddressBytes();

            for (int i = startIpBytes[3]; i <= endIpBytes[3]; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var buffer = (byte[])startIpBytes.Clone();
                buffer[3] = (byte)i;
                var ipToPing = new IPAddress(buffer);
                tasks.Add(PingAndResolveAsync(pingSender, ipToPing, cancellationToken));
            }

            var results = await Task.WhenAll(tasks);
            return new List<(string IpAddress, string HostName, string Status)>(results);
        }

        private async Task<(string IpAddress, string HostName, string Status)> PingAndResolveAsync(Ping pingSender, IPAddress ipToPing, CancellationToken cancellationToken)
        {
            using (var localPingSender = new Ping())
            {
                var reply = await localPingSender.SendPingAsync(ipToPing, 250);
                if (cancellationToken.IsCancellationRequested)
                {
                    return (ipToPing.ToString(), "", "Canceled");
                }

                if (reply.Status == IPStatus.Success)
                {
                    string hostName = "Не виявлено";
                    try
                    {
                        var hostEntry = await Dns.GetHostEntryAsync(ipToPing);
                        hostName = hostEntry.HostName;
                    }
                    catch
                    {
                    }
                    return (ipToPing.ToString(), hostName, "Up");
                }
            }

            return (ipToPing.ToString(), "", "Down");
        }

        public (IPAddress, IPAddress) GetLocalIpRange()
        {
            var netInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n => (n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                                     n.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                                     n.OperationalStatus == OperationalStatus.Up);

            if (netInterface == null)
                throw new InvalidOperationException("No network adapters with an IPv4 address in the system!");

            var ipInfo = netInterface.GetIPProperties().UnicastAddresses
                .FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);

            if (ipInfo == null)
                throw new InvalidOperationException("No IPv4 address found.");

            var ipAddress = ipInfo.Address;
            var ipMask = ipInfo.IPv4Mask;

            var networkAddress = GetNetworkAddress(ipAddress, ipMask);
            var broadcastAddress = GetBroadcastAddress(ipAddress, ipMask);
            return (networkAddress, broadcastAddress);
        }

        private IPAddress GetNetworkAddress(IPAddress address, IPAddress mask)
        {
            byte[] ipAddressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = mask.GetAddressBytes();
            byte[] broadcastAddress = new byte[ipAddressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAddressBytes[i] & subnetMaskBytes[i]);
            }
            return new IPAddress(broadcastAddress);
        }

        private IPAddress GetBroadcastAddress(IPAddress address, IPAddress mask)
        {
            byte[] ipAddressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = mask.GetAddressBytes();
            byte[] broadcastAddress = new byte[ipAddressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAddressBytes[i] | (~subnetMaskBytes[i]));
            }
            return new IPAddress(broadcastAddress);
        }

        public string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + ipAddress;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            pProcess.WaitForExit();

            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                         + "-" + substrings[4] + "-" + substrings[5] + "-"
                         + substrings[6] + "-" + substrings[7] + "-"
                         + substrings[8].Substring(0, 2);
                return macAddress;
            }

            return macAddress;
        }

        public async Task<string> GetDeviceType(string ipAddress)
        {
            string deviceType = "Unknown";

            if (await IsPortOpenAsync(ipAddress, new[] { 135, 139, 445 }))
            {
                deviceType = "Windows PC";
            }
            else if (await IsPortOpenAsync(ipAddress, new[] { 22 }))
            {
                deviceType = "UNIX/Linux PC";
            }
            else if (await IsPortOpenAsync(ipAddress, new[] { 80, 443 }))
            {
                deviceType = "Router/Ap";
            }
            else if (await IsPortOpenAsync(ipAddress, new[] { 515, 631, 9100 }))
            {
                deviceType = "Printer";
            }
            else if (await IsPortOpenAsync(ipAddress, new[] { 2049 }))
            {
                deviceType = "Network Storage";
            }

            return deviceType;
        }

        public async Task<bool> IsPortOpenAsync(string ipAddress, int[] ports)
        {
            var tasks = ports.Select(async port =>
            {
                using (var client = new TcpClient())
                {
                    try
                    {
                        var task = client.ConnectAsync(ipAddress, port);
                        return await Task.WhenAny(task, Task.Delay(500)) == task && client.Connected;
                    }
                    catch
                    {
                        return false;
                    }
                }
            });

            var results = await Task.WhenAll(tasks);
            return results.Any(r => r);
        }

        public void LoadOuiDatabase(string path)
        {
            string pattern = @"(?<oui>^[A-F0-9]{6})\s+\(base 16\)\s+(?<vendor>.+)";
            var regex = new Regex(pattern, RegexOptions.Multiline);

            var fileContent = File.ReadAllText(path);

            var matches = regex.Matches(fileContent);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    var oui = match.Groups["oui"].Value;
                    var vendor = match.Groups["vendor"].Value.Trim();

                    if (!_ouiDictionary.ContainsKey(oui))
                    {
                        _ouiDictionary[oui] = vendor;
                    }
                }
            }
        }

        public string GetManufacturerByMac(string macAddress)
        {
            var cleanedMac = macAddress.Replace(":", "").Replace("-", "").ToUpper();

            return cleanedMac.Length >= 6 && _ouiDictionary.TryGetValue(cleanedMac.Substring(0, 6), out var vendor)
                ? vendor
                : "Не визначено";
        }

        public async Task<string> GetWindowsOperatingSystemInfo(string ipAddress)
        {
            try
            {
                var username = ConfigurationManager.AppSettings["WMIUsername"];
                var password = ConfigurationManager.AppSettings["WMIPassword"];

                var options = new ConnectionOptions
                {
                    Impersonation = ImpersonationLevel.Impersonate,
                    Username = username,
                    Password = password
                };

                var scope = new ManagementScope($"\\\\{ipAddress}\\root\\cimv2", options);
                scope.Connect();

                var query = new ObjectQuery("SELECT Caption FROM Win32_OperatingSystem");
                var searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject mo in searcher.Get())
                {
                    return mo["Caption"].ToString();
                }
            }
            catch (Exception ex)
            {
                return $"Unable to retrieve OS info: {ex.Message}";
            }

            return "Unknown";
        }

        public async Task<string> GetWindowsMachineName(string ipAddress)
        {
            try
            {
                var username = ConfigurationManager.AppSettings["WMIUsername"];
                var password = ConfigurationManager.AppSettings["WMIPassword"];

                var options = new ConnectionOptions
                {
                    Impersonation = ImpersonationLevel.Impersonate,
                    Username = username,
                    Password = password
                };

                var scope = new ManagementScope($"\\\\{ipAddress}\\root\\cimv2", options);
                scope.Connect();

                var query = new ObjectQuery("SELECT Name FROM Win32_ComputerSystem");
                var searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject mo in searcher.Get())
                {
                    return mo["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                return $"Unable to retrieve Machine Name: {ex.Message}";
            }

            return "Unknown";
        }

        public async Task<string> GetHttpData(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var titleTagStart = content.IndexOf("<title>", StringComparison.OrdinalIgnoreCase);
                    var titleTagEnd = content.IndexOf("</title>", StringComparison.OrdinalIgnoreCase);

                    if (titleTagStart >= 0 && titleTagEnd > titleTagStart)
                    {
                        return content.Substring(titleTagStart + 7, titleTagEnd - titleTagStart - 7).Trim();
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }

            return "No title";
        }

        public string GetSNMPData(string ipAddress, string oid)
        {
            try
            {
                var target = new UdpTarget(IPAddress.Parse(ipAddress), 161, 2000, 1);
                var community = new OctetString("public");
                var pdu = new Pdu(PduType.Get);
                pdu.VbList.Add(oid);
                var request = new AgentParameters(community)
                {
                    Version = SnmpVersion.Ver2
                };

                var response = target.Request(pdu, request);
                if (response != null && response.Pdu.ErrorStatus == 0)
                {
                    return response.Pdu.VbList[0].Value.ToString();
                }
                return "No data received";
            }
            catch (Exception ex)
            {
                return $"SNMP Error: {ex.Message}";
            }
        }

        public string GetSystemDescription(string ipAddress)
        {
            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.1.0");
        }

        public string GetSystemName(string ipAddress)
        {
            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.5.0");
        }

        public string GetSystemUptime(string ipAddress)
        {
            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.3.0");
        }

        public string GetSystemContact(string ipAddress)
        {
            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.4.0");
        }

        public string GetSystemLocation(string ipAddress)
        {
            return GetSNMPData(ipAddress, "1.3.6.1.2.1.1.6.0");
        }

        // NetBIOS
        public string GetNetBiosName(string ipAddress)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "nbtstat",
                        Arguments = "-A " + ipAddress,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var match = Regex.Match(output, @"Name\s+<\d+>\s+UNIQUE\s+(\S+)");
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }
            catch (Exception ex)
            {
                return $"NetBIOS Error: {ex.Message}";
            }

            return "Unknown";
        }

        // SMB
        public string GetSmbShares(string ipAddress)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "net",
                        Arguments = $"view \\\\{ipAddress}",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output;
            }
            catch (Exception ex)
            {
                return $"SMB Error: {ex.Message}";
            }
        }

        // SSH
        public string ExecuteSshCommand(string ipAddress, string username, string password, string command)
        {
            try
            {
                using (var client = new SshClient(ipAddress, username, password))
                {
                    client.Connect();
                    var cmd = client.RunCommand(command);
                    client.Disconnect();
                    return cmd.Result;
                }
            }
            catch (Exception ex)
            {
                return $"SSH Error: {ex.Message}";
            }
        }
    }





}

