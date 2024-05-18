using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class db_Helper
    {
        public void LoadDatabases(string connectionString, ComboBox cmb_Databases)
        {

            string sql = "SELECT datname FROM pg_database WHERE datistemplate = false AND datname != 'Admin';";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            cmb_Databases.Items.Clear();
                            while (dr.Read())
                            {
                                cmb_Databases.Items.Add(dr["datname"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка завантаження бази даних ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void LoadTables(string connectionString, Control control)
        {
            string sql = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (control is ListBox listBox)
                            {
                                listBox.Items.Clear();
                                while (dr.Read())
                                {
                                    listBox.Items.Add(dr["table_name"].ToString());
                                }
                            }
                            else if (control is ComboBox comboBox)
                            {
                                comboBox.Items.Clear();
                                while (dr.Read())
                                {
                                    var tableName = dr["table_name"].ToString();
                                    comboBox.Items.Add(tableName);
                                    Console.WriteLine($"Added table: {tableName}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка завантаження таблиці", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void LoadOperationLogs(ListView lst_DB_Logs)
        {

            string sql = "SELECT id, timestamp, operation_type, table_name, details FROM operation_log ORDER BY timestamp DESC;";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("AdminConnection")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            lst_DB_Logs.Items.Clear();
                            while (dr.Read())
                            {
                                var item = new ListViewItem(dr["id"].ToString());
                                item.SubItems.Add(dr["timestamp"].ToString());
                                item.SubItems.Add(dr["operation_type"].ToString());
                                item.SubItems.Add(dr["table_name"].ToString());
                                item.SubItems.Add(dr["details"].ToString());

                                lst_DB_Logs.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження записів: {ex.Message}", "Помилка логування", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void LogOperationInAdminDb(string operationType, string tableName, string details)
        {
            string sql = "INSERT INTO operation_log (operation_type, table_name, details) VALUES (@operationType, @tableName, @details)";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("AdminConnection")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@operationType", operationType);
                        cmd.Parameters.AddWithValue("@tableName", tableName);
                        cmd.Parameters.AddWithValue("@details", details);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка логування", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
