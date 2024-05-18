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
            LoadUserFullName();
            LoadUserData();
            InitializeListView();
            InitializeContextMenu();
        }

        private void InitializeListView()
        {
            listViewUserEquipment.View = View.Details;
            listViewUserEquipment.Columns.Add("Назва", 100);
            listViewUserEquipment.Columns.Add("ІН", 100);
            listViewUserEquipment.Columns.Add("Тип", 80);
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

        private void LoadUserFullName()
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
        }

        private void LoadUserData()
        {
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
            // Загрузите задачи пользователя (оставим этот метод без изменений)
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
