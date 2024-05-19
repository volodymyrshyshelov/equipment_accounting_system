using equipment_accounting_system.Additional_Forms;
using equipment_accounting_system.Classes;
using Newtonsoft.Json.Linq;
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
    public partial class home_page : UserControl
    {
        private int userID;
        private string userFullName;

        public home_page(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadUserData();
            InitializeListViewEquipment();
            InitializeListViewTasks();
            InitializeContextMenu();
            InitializeUserTasksContextMenu();
        }

        private void InitializeListViewEquipment()
        {
            listViewUserEquipment.View = View.Details;
            listViewUserEquipment.Columns.Add("Назва", 100);
            listViewUserEquipment.Columns.Add("ІН", 100);
            listViewUserEquipment.Columns.Add("Тип", 80);
        }

        private void InitializeListViewTasks()
        {
            listViewUserTasks.View = View.Details;
            listViewUserTasks.Columns.Add("ІН", 90);
            listViewUserTasks.Columns.Add("Тип", 100);
            listViewUserTasks.Columns.Add("Пріорітет", 90);
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem detailsMenuItem = new ToolStripMenuItem("Деталі");
            detailsMenuItem.Click += new EventHandler(DetailsMenuItem_Click);
            contextMenu.Items.Add(detailsMenuItem);
            listViewUserEquipment.ContextMenuStrip = contextMenu;
        }

        private void DetailsMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUserEquipment.SelectedItems.Count > 0)
            {
                int equipmentId = Convert.ToInt32(listViewUserEquipment.SelectedItems[0].Tag);
                frm_Add_Edit_Equipment editForm = new frm_Add_Edit_Equipment(equipmentId);
                editForm.ShowDialog();
                LoadUserEquipment();
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string query = "SELECT fullname FROM userlist WHERE userid = @UserID";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userFullName = reader["fullname"].ToString();
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки полного имени пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadUserEquipment();
            LoadTotalEquipment();
            LoadUserTasks();
        }

        private void LoadUserEquipment()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();
                    string query = "SELECT id, name, inventorynumber, type FROM equipment1 WHERE workerusername = @WorkerFullName";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkerFullName", userFullName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            listViewUserEquipment.Items.Clear();
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["name"].ToString());
                                item.SubItems.Add(reader["inventorynumber"].ToString());
                                item.SubItems.Add(reader["type"].ToString());
                                item.Tag = reader["id"];
                                listViewUserEquipment.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTotalEquipment()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();

                    string totalQuery = "SELECT table_name FROM information_schema.tables WHERE table_schema='public'";
                    List<string> tableNames = new List<string>();

                    using (var totalCmd = new NpgsqlCommand(totalQuery, conn))
                    {
                        using (var reader = totalCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tableNames.Add(reader["table_name"].ToString());
                            }
                        }
                    }

                    totalCount = 0;
                    userCount = 0;

                    foreach (var tableName in tableNames)
                    {
                        string countQuery = $"SELECT COUNT(*) FROM {tableName}";
                        string userCountQuery = $"SELECT COUNT(*) FROM {tableName} WHERE workerusername = @WorkerFullName";

                        using (var countCmd = new NpgsqlCommand(countQuery, conn))
                        using (var userCountCmd = new NpgsqlCommand(userCountQuery, conn))
                        {
                            userCountCmd.Parameters.AddWithValue("@WorkerFullName", userFullName);

                            totalCount += Convert.ToInt32(countCmd.ExecuteScalar());
                            userCount += Convert.ToInt32(userCountCmd.ExecuteScalar());
                        }
                    }

                    lblTotalEquipment.Text = $"{totalCount}";
                    lblUserEquipmentCount.Text = $"{userCount}";


                    infographicPanel.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserTasks()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
                {
                    conn.Open();
                    string query = @"
                    SELECT in_number, type, priority
                    FROM planning
                    WHERE workername = @WorkerFullName
                      AND status != 'Виконано'
                      AND current_date BETWEEN start_date AND end_date";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkerFullName", userFullName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            listViewUserTasks.Items.Clear();
                            while (reader.Read())
                            {
                                var item = new ListViewItem(reader["in_number"].ToString());
                                item.SubItems.Add(reader["type"].ToString());
                                item.SubItems.Add(reader["priority"].ToString());
                                listViewUserTasks.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки задач пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUserTasksContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            var editItem = new ToolStripMenuItem("Редагувати завдання");

            editItem.Click += EditUserTask_Click;

            contextMenu.Items.Add(editItem);

            listViewUserTasks.ContextMenuStrip = contextMenu;
        }

        private void EditUserTask_Click(object sender, EventArgs e)
        {
            if (listViewUserTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть завдання для редагування.");
                return;
            }

            var selectedItem = listViewUserTasks.SelectedItems[0];
            var inNumber = selectedItem.SubItems[0].Text;
            int planId = GetPlanIdByInNumber(inNumber);

            if (planId != 0)
            {
                var addEditForm = new frm_Add_Edit_Plans(planId);
                addEditForm.ShowDialog();

                // Обновляем список задач после редактирования
                LoadUserTasks();
            }
            else
            {
                MessageBox.Show("Не вдалося знайти запис з вказаним in_number.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetPlanIdByInNumber(string inNumber)
        {
            int planId = 0;
            string sql = "SELECT id FROM planning WHERE in_number = @in_number";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@in_number", inNumber);
                        planId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Task Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return planId;
        }

        private void chart_Paint(object sender, PaintEventArgs e)
        {
            float[] values = { userCount, totalCount - userCount }; // Передача значений в график
            Color[] colors = { Color.Blue, Color.Green };

            charts_Painter painter = new charts_Painter();
            painter.pie_chart_painter(e, values, colors);
        }

        private int totalCount; // Общее количество записей
        private int userCount; // Количество записей, закрепленных за пользователем

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
