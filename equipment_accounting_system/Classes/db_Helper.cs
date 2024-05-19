using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

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
                            else if (control is ListView listView)
                            {
                                listView.Items.Clear();
                                while (dr.Read())
                                {
                                    listView.Items.Add(new ListViewItem(dr["table_name"].ToString()));
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

        // Новые методы для работы с таблицами departaments и usersroles
        public void LoadDepartments(Control control)
        {
            string sql = "SELECT id, name FROM departments";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (control is ListView lstv_depts)
                            {
                                lstv_depts.Items.Clear();
                                while (dr.Read())
                                {
                                    var item = new ListViewItem(dr["id"].ToString());
                                    item.SubItems.Add(dr["name"].ToString());
                                    lstv_depts.Items.Add(item);
                                }
                            }
                            else if (control is ComboBox cmb_depts)
                            {
                                cmb_depts.Items.Clear();
                                while (dr.Read())
                                {
                                    cmb_depts.Items.Add(dr["name"].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження записів: {ex.Message}", "Помилка завантаження відділів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LoadRoles(Control control)
        {
            string sql = "SELECT id, role_name FROM usersroles";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (control is ListView lstv_roles)
                            {
                                lstv_roles.Items.Clear();
                                while (dr.Read())
                                {
                                    var item = new ListViewItem(dr["id"].ToString());
                                    item.SubItems.Add(dr["role_name"].ToString());
                                    lstv_roles.Items.Add(item);
                                }
                            }
                            else if (control is ComboBox cmb_roles)
                            {
                                cmb_roles.Items.Clear();
                                while (dr.Read())
                                {
                                    cmb_roles.Items.Add(dr["role_name"].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження записів: {ex.Message}", "Помилка завантаження ролей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void AddDepartment(string departmentName)
        {
            string sql = "INSERT INTO departments (name) VALUES (@departmentName)";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка додавання відділу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AddRole(string roleName)
        {
            string sql = "INSERT INTO usersroles (role_name) VALUES (@roleName)";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@roleName", roleName);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка додавання ролі", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateDepartment(int id, string departmentName)
        {
            string sql = "UPDATE departments SET name = @departmentName WHERE id = @id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка оновлення відділу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateRole(int id, string roleName)
        {
            string sql = "UPDATE usersroles SET role_name = @roleName WHERE id = @id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@roleName", roleName);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка оновлення ролі", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteDepartment(int id)
        {
            string sql = "DELETE FROM departments WHERE id = @id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка видалення відділу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteRole(int id)
        {
            string sql = "DELETE FROM usersroles WHERE id = @id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DeptAndRoles")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка видалення ролі", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void CreateTable(string connectionString, string tableName)
        {
            string sql = $@"
        CREATE TABLE {tableName} (
            Id SERIAL PRIMARY KEY,
            InventoryNumber VARCHAR(50),
            EqImage BYTEA,
            Name VARCHAR(100),
            Ip VARCHAR(50),
            Mac VARCHAR(50),
            Type VARCHAR(50),
            Manufacturer VARCHAR(100),
            LastRoutineMaintenanceDate TIMESTAMP,
            NextRoutineMaintenanceDate TIMESTAMP,
            WorkerUsername VARCHAR(100)
        )";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Таблиця {tableName} успішно створена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка створення таблиці: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DropTable(string connectionString, string tableName)
        {
            string sql = $"DROP TABLE IF EXISTS {tableName}";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Таблиця {tableName} успішно видалена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка видалення таблиці: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
