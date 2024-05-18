using equipment_accounting_system.Additional_Forms;
using equipment_accounting_system.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace equipment_accounting_system.Controls
{
    public partial class scanning_page : UserControl
    {
        
        private bool isScanning = false;
        private network_Scanner scanner;
        private CancellationTokenSource cts_Scan;

        public scanning_page()
        {
            InitializeComponent();
            scanner = new network_Scanner();
            scanner.LoadOuiDatabase("oui.txt");
            InitializeScanContextMenu();
        }

        private async void btn_Start_Scan_Click_1(object sender, EventArgs e)
        {
            

            if (!isScanning)
            {
                isScanning = true;
                btn_Start_Scan.Text = "Зупинити сканування";
                lstvw_Scan.Items.Clear();
                lbl_Scan_Status.Text = "Сканування мережі...";
                lbl_Scan_Status.ForeColor = System.Drawing.Color.Green;

                var (startIp, endIp) = scanner.GetLocalIpRange();
                cts_Scan = new CancellationTokenSource();

                try
                {
                    var results = await scanner.ScanNetworkRangeAsync(startIp, endIp, cts_Scan.Token);

                    foreach (var (IpAddress, HostName, Status) in results)
                    {
                        if (cts_Scan.Token.IsCancellationRequested)
                        {
                            break;
                        }

                        this.Invoke(new Action(() =>
                        {
                            lbl_Scan_Status.Text = $"Сканування адреси - {IpAddress}";
                        }));

                        string DeviceType = await scanner.GetDeviceType(IpAddress);
                        string MacAddress = scanner.GetMacAddress(IpAddress);
                        string Manufacturer = scanner.GetManufacturerByMac(MacAddress);

                        bool existsInDatabase = await CheckIfEquipmentExists(IpAddress, MacAddress);

                        if (!string.IsNullOrEmpty(IpAddress) && Status == "Up")
                        {
                            this.Invoke(new Action(() =>
                            {
                                var item = new ListViewItem(new string[] { HostName, IpAddress, MacAddress, DeviceType, Manufacturer, existsInDatabase ? "Так" : "Ні" });
                                // Убедитесь, что Tag правильно устанавливается
                                item.Tag = new EquipmentInfo
                                {
                                    IpAddress = IpAddress,
                                    HostName = HostName,
                                    DeviceType = DeviceType,
                                    MacAddress = MacAddress,
                                    Manufacturer = Manufacturer
                                };
                                lstvw_Scan.Items.Add(item);
                            }));
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    lbl_Scan_Status.Text = "Сканування завершено";
                    lbl_Scan_Status.ForeColor = System.Drawing.Color.Red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка сканування", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    isScanning = false;

                    if (cts_Scan.Token.IsCancellationRequested)
                    {
                        lbl_Scan_Status.Text = "Сканування зупинено";
                        lbl_Scan_Status.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lbl_Scan_Status.Text = "Сканування завершено!";
                        lbl_Scan_Status.ForeColor = System.Drawing.Color.Green;
                    }

                    btn_Start_Scan.Text = "Сканувати мережу";
                }
            }
            else
            {
                cts_Scan?.Cancel();
            }
        }

        private async Task<bool> CheckIfEquipmentExists(string ipAddress, string macAddress)
        {
            string connectionString = ConfigurationManager.AppSettings.Get("Inventory");

            using (var conn = new NpgsqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT COUNT(*) FROM equipment1 WHERE ip = @Ip OR mac = @Mac";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ip", ipAddress);
                    cmd.Parameters.AddWithValue("@Mac", macAddress);

                    int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    return count > 0;
                }
            }
        }
        private void InitializeScanContextMenu()
        {
            
            var contextMenu = new ContextMenuStrip();
            var addItem = new ToolStripMenuItem("Додати до таблиці");
            var additionalInfoItem = new ToolStripMenuItem("Детальна інформація");

            addItem.Click += AddScanResultToDatabase_Click;
            additionalInfoItem.Click += AdditionalInfo_Click;

            contextMenu.Items.Add(addItem);
            contextMenu.Items.Add(additionalInfoItem);

            lstvw_Scan.ContextMenuStrip = contextMenu;

        }

        private void AddScanResultToDatabase_Click(object sender, EventArgs e)
        {
            

            if (lstvw_Scan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіт результат для збереження.");
                return;
            }

            var selectedItem = lstvw_Scan.SelectedItems[0];
            var equipmentInfo = selectedItem.Tag as EquipmentInfo;

            // Проверка, что данные корректно передаются
            if (equipmentInfo == null)
            {
                MessageBox.Show("Дані не передаються у форму.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm_Add_Edit_Equipment editForm = new frm_Add_Edit_Equipment(equipmentInfo);
            editForm.ShowDialog();
        }

        private async void AdditionalInfo_Click(object sender, EventArgs e)
        {
            
            if (lstvw_Scan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a scan result.");
                return;
            }

            var selectedItem = lstvw_Scan.SelectedItems[0];
            string ipAddress = selectedItem.SubItems[1].Text;

            

            string operatingSystem = await scanner.GetWindowsOperatingSystemInfo(ipAddress);
            string machineName = await scanner.GetWindowsMachineName(ipAddress);
            string httpTitle = await scanner.GetHttpData($"http://{ipAddress}");

            MessageBox.Show($"IP Address: {ipAddress}\n" +
                            $"Host Name: {selectedItem.SubItems[0].Text}\n" +
                            $"Device Type: {selectedItem.SubItems[3].Text}\n" +
                            $"MAC Address: {selectedItem.SubItems[2].Text}\n" +
                            $"Manufacturer: {selectedItem.SubItems[4].Text}\n" +
                            $"Operating System: {operatingSystem}\n" +
                            $"Machine Name: {machineName}\n" +
                            $"HTTP Title: {httpTitle}",
                            "Additional Information");
        }






    }
}
