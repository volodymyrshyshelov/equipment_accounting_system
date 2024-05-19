using equipment_accounting_system.Classes;
using Lextm.SharpSnmpLib;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace equipment_accounting_system.Additional_Forms
{
    public partial class frm_Add_Edit_Equipment : Form
    {
        private int? equipmentId = null;
        private EquipmentInfo equipmentInfo;
        private db_Helper dbHelper;
        private readonly log_Helper logHelper;

        public frm_Add_Edit_Equipment()
        {
            InitializeComponent();
            LoadUsers();
            string connectionString = ConfigurationManager.AppSettings.Get("Inventory");
            dbHelper = new db_Helper();
            dbHelper.LoadTables(connectionString, cmb_tables);
            logHelper = new log_Helper(ConfigurationManager.AppSettings.Get("LogConnection"));
            InitializeDateTimePickers();
        }
        public frm_Add_Edit_Equipment(int equipmentId)
        {
            InitializeComponent();
            this.equipmentId = equipmentId;
            LoadEquipmentData();
            LoadUsers();
            string connectionString = ConfigurationManager.AppSettings.Get("Inventory");
            dbHelper = new db_Helper();
            dbHelper.LoadTables(connectionString, cmb_tables);
            logHelper = new log_Helper(ConfigurationManager.AppSettings.Get("LogConnection"));
            InitializeDateTimePickers();
        }
        public frm_Add_Edit_Equipment(EquipmentInfo equipmentInfo)
        {
            InitializeComponent();
            this.equipmentInfo = equipmentInfo;
            string connectionString = ConfigurationManager.AppSettings.Get("Inventory");
            dbHelper = new db_Helper();
            dbHelper.LoadTables(connectionString, cmb_tables);
            LoadEquipmentData();
            LoadUsers();
            logHelper = new log_Helper(ConfigurationManager.AppSettings.Get("LogConnection"));
            InitializeDateTimePickers();
        }
        private void InitializeDateTimePickers()
        {
            dtp_LastRoutineMaintenanceDate.Format = DateTimePickerFormat.Custom;
            dtp_LastRoutineMaintenanceDate.CustomFormat = "dd-MM-yyyy";

            dtp_NextRoutineMaintenanceDate.Format = DateTimePickerFormat.Custom;
            dtp_NextRoutineMaintenanceDate.CustomFormat = "dd-MM-yyyy";
        }

        private void LoadEquipmentData()
        {
            if (equipmentInfo != null)
            {
                txt_Ip.Text = equipmentInfo.IpAddress;
                txt_name.Text = equipmentInfo.HostName;
                txt_Type.Text = equipmentInfo.DeviceType;
                txt_Mac.Text = equipmentInfo.MacAddress;
                txt_Manufacturer.Text = equipmentInfo.Manufacturer;
            }
            if (equipmentId.HasValue)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                    {
                        conn.Open();
                        string selectQuery = "SELECT * FROM equipment1 WHERE Id = @Id";
                        using (var cmd = new NpgsqlCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", equipmentId.Value);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txt_inventory_number.Text = reader["inventorynumber"].ToString();
                                    txt_name.Text = reader["name"].ToString();
                                    txt_Ip.Text = reader["ip"].ToString();
                                    txt_Mac.Text = reader["mac"].ToString();
                                    txt_Type.Text = reader["type"].ToString();
                                    txt_Manufacturer.Text = reader["manufacturer"].ToString();
                                    dtp_LastRoutineMaintenanceDate.Value = reader["lastroutinemaintenancedate"] != DBNull.Value ? Convert.ToDateTime(reader["lastroutinemaintenancedate"]) : DateTime.Now;
                                    dtp_NextRoutineMaintenanceDate.Value = reader["nextroutinemaintenancedate"] != DBNull.Value ? Convert.ToDateTime(reader["nextroutinemaintenancedate"]) : DateTime.Now;
                                    cmbWorkerUsername.SelectedItem = reader["workerusername"].ToString();

                                    if (reader["eqimage"] != DBNull.Value)
                                    {
                                        byte[] imageData = (byte[])reader["eqimage"];
                                        using (MemoryStream ms = new MemoryStream(imageData))
                                        {
                                            btn_add_image.Image = Image.FromStream(ms);
                                        }
                                    }
                                }
                            }
                        }

                        var logEntry = new log_Entry
                        {
                            UserId = 0,
                            TableName = "equipment1",
                            LogType = "INFO",
                            LogMessage = "Завантаження даних обладнання.",
                            Details = $"Equipment ID: {equipmentId.Value}"
                        };
                        logHelper.InsertLogEntry(logEntry);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }








        private void btn_add_image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    btn_add_image.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();
                    string tableName = cmb_tables.SelectedItem?.ToString();
                    if (string.IsNullOrEmpty(tableName))
                    {
                        MessageBox.Show("Будь ласка, оберіть таблицю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query;

                    if (equipmentId.HasValue)
                    {
                        query = $"UPDATE {tableName} SET inventorynumber = @InventoryNumber, name = @Name, ip = @Ip, mac = @Mac, type = @Type, manufacturer = @Manufacturer, lastroutinemaintenancedate = @LastRoutineMaintenanceDate, nextroutinemaintenancedate = @NextRoutineMaintenanceDate, eqimage = @EqImage, workerusername = @WorkerUsername WHERE Id = @Id";
                    }
                    else
                    {
                        query = $"INSERT INTO {tableName} (inventorynumber, name, ip, mac, type, manufacturer, lastroutinemaintenancedate, nextroutinemaintenancedate, eqimage, workerusername) VALUES (@InventoryNumber, @Name, @Ip, @Mac, @Type, @Manufacturer, @LastRoutineMaintenanceDate, @NextRoutineMaintenanceDate, @EqImage, @WorkerUsername)";
                    }

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InventoryNumber", txt_inventory_number.Text);
                        cmd.Parameters.AddWithValue("@Name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@Ip", txt_Ip.Text);
                        cmd.Parameters.AddWithValue("@Mac", txt_Mac.Text);
                        cmd.Parameters.AddWithValue("@Type", txt_Type.Text);
                        cmd.Parameters.AddWithValue("@Manufacturer", txt_Manufacturer.Text);
                        cmd.Parameters.AddWithValue("@LastRoutineMaintenanceDate", dtp_LastRoutineMaintenanceDate.Value);
                        cmd.Parameters.AddWithValue("@NextRoutineMaintenanceDate", dtp_NextRoutineMaintenanceDate.Value);
                        cmd.Parameters.AddWithValue("@WorkerUsername", cmbWorkerUsername.SelectedItem.ToString());

                        if (btn_add_image.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                btn_add_image.Image.Save(ms, btn_add_image.Image.RawFormat);
                                cmd.Parameters.AddWithValue("@EqImage", ms.ToArray());
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EqImage", DBNull.Value);
                        }

                        if (equipmentId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Id", equipmentId.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var logEntry = new log_Entry
                    {
                        UserId = 0,
                        TableName = tableName,
                        LogType = equipmentId.HasValue ? "INFO" : "INSERT",
                        LogMessage = equipmentId.HasValue ? "Оновлення даних обладнання." : "Додано новий запис.",
                        Details = $"InventoryNumber: {txt_inventory_number.Text}, Name: {txt_name.Text}"
                    };
                    logHelper.InsertLogEntry(logEntry);






                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbWorkerUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string selectQuery = "SELECT fullname FROM userlist";
                    using (var cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbWorkerUsername.Items.Add(reader["fullname"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки пользователей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtp_LastRoutineMaintenanceDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
