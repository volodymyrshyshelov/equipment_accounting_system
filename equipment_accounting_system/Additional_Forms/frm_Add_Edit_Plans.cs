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

namespace equipment_accounting_system.Additional_Forms
{
    public partial class frm_Add_Edit_Plans : Form
    {
        private int taskId;
        private readonly log_Helper logHelper;

        public frm_Add_Edit_Plans()
        {
            InitializeComponent();
            LoadUsers();
            InitializeComboBoxes();
            InitializeDateTimePickers();
            logHelper = new log_Helper(ConfigurationManager.AppSettings.Get("LogConnection"));
        }
        public frm_Add_Edit_Plans(int taskId)
        {  
            InitializeComponent();
            InitializeComboBoxes();
            LoadUsers();
            InitializeDateTimePickers();
            this.taskId = taskId;
            LoadTaskData();
            logHelper = new log_Helper(ConfigurationManager.AppSettings.Get("LogConnection"));
        }
        private void InitializeDateTimePickers()
        {
            dp_start_date.Format = DateTimePickerFormat.Custom;
            dp_start_date.CustomFormat = "dd-MM-yyyy";

            dp_end_date.Format = DateTimePickerFormat.Custom;
            dp_end_date.CustomFormat = "dd-MM-yyyy";
        }
        private void LoadTaskData()
        {
            if (taskId != 0)
            {
                string sql = "SELECT id, in_number, name, status, workername, priority, type, start_date, end_date, details FROM planning WHERE id = @id";

                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", taskId);

                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    txt_in_number.Text = dr["in_number"].ToString();
                                    txt_name.Text = dr["name"].ToString();
                                    cmb_status.SelectedItem = dr["status"].ToString();
                                    cmb_workername.SelectedItem = dr["workername"].ToString();
                                    cmb_priority.SelectedItem = dr["priority"].ToString();
                                    cmb_type.SelectedItem = dr["type"].ToString();
                                    dp_start_date.Value = Convert.ToDateTime(dr["start_date"]);
                                    dp_end_date.Value = Convert.ToDateTime(dr["end_date"]);
                                    txt_details.Text = dr["details"].ToString();
                                }
                            }
                        }
                        var logEntry = new log_Entry
                        {
                            UserId = 0, 
                            TableName = "planning",
                            LogType = "INFO",
                            LogMessage = "Завантаження задач.",
                            Details = $"Task ID: {taskId}"
                        };
                        logHelper.InsertLogEntry(logEntry);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Task Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (taskId == 0)
            {
                AddNewTask();
            }
            else
            {
                UpdateTask();
            }
        }
        private void AddNewTask()
        {
            string sql = "INSERT INTO planning (in_number, name, status, workername, priority, type, start_date, end_date, details) VALUES (@in_number, @name, @status, @workername, @priority, @type, @start_date, @end_date, @details)";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@in_number", txt_in_number.Text);
                        cmd.Parameters.AddWithValue("@name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@status", cmb_status.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@workername", cmb_workername.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@priority", cmb_priority.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@type", cmb_type.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@start_date", dp_start_date.Value);
                        cmd.Parameters.AddWithValue("@end_date", dp_end_date.Value);
                        cmd.Parameters.AddWithValue("@details", txt_details.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Запис додано успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var logEntry = new log_Entry
                        {
                            UserId = 0, 
                            TableName = "planning",
                            LogType = "INFO",
                            LogMessage = "Додано новий запис.",
                            Details = $"InNumber: {txt_in_number.Text}, Name: {txt_name.Text}"
                        };
                        logHelper.InsertLogEntry(logEntry);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Task Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateTask()
        {
            string sql = "UPDATE planning SET in_number = @in_number, name = @name, status = @status, workername = @workername, priority = @priority, type = @type, start_date = @start_date, end_date = @end_date, details = @details WHERE id = @id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", taskId);
                        cmd.Parameters.AddWithValue("@in_number", txt_in_number.Text);
                        cmd.Parameters.AddWithValue("@name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@status", cmb_status.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@workername", cmb_workername.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@priority", cmb_priority.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@type", cmb_type.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@start_date", dp_start_date.Value);
                        cmd.Parameters.AddWithValue("@end_date", dp_end_date.Value);
                        cmd.Parameters.AddWithValue("@details", txt_details.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Запис оновлено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var logEntry = new log_Entry
                        {
                            UserId = 0, 
                            TableName = "planning",
                            LogType = "INFO",
                            LogMessage = "Запис оновлено.",
                            Details = $"Task ID: {taskId}, InNumber: {txt_in_number.Text}, Name: {txt_name.Text}"
                        };
                        logHelper.InsertLogEntry(logEntry);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Task Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                                cmb_workername.Items.Add(reader["fullname"].ToString());
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
        private void InitializeComboBoxes()
        {
            cmb_type.Items.AddRange(new string[] { "Ремонт", "Обслуговування", "Діагностика" });
            cmb_priority.Items.AddRange(new string[] { "Низький", "Середній", "Високий", "Негайний" });
            cmb_status.Items.AddRange(new string[] { "В Обробці", "Виконується", "Виконано" });
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmb_workername_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmb_priority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dp_start_date_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
