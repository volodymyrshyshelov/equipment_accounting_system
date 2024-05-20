using equipment_accounting_system.Additional_Forms;
using equipment_accounting_system.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class inventory_page : UserControl
    {
        private ContextMenuStrip contextMenu;
        private readonly log_Helper logHelper;
        public inventory_page()
        {
            InitializeComponent();
            LoadTables();
            InitializeContextMenu();
            logHelper = new log_Helper(ConfigurationManager.AppSettings.Get("LogConnection"));
            dgv_inventory.CellFormatting += dgv_inventory_CellFormatting;
        }
        private void dgv_inventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_inventory.Columns[e.ColumnIndex].Name == "eqimage" && e.Value != null)
            {
                byte[] imageBytes = (byte[])e.Value;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image img = Image.FromStream(ms);
                    e.Value = new Bitmap(img, new Size(50, 50));
                }
                e.FormattingApplied = true;
            }
        }


        private void inventory_page_Load(object sender, EventArgs e)
        {

        }
        private void InitializeContextMenu()
        {
            contextMenu = new ContextMenuStrip();
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Add");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");

            editMenuItem.Click += new EventHandler(EditMenuItem_Click);
            addMenuItem.Click += new EventHandler(AddMenuItem_Click);
            deleteMenuItem.Click += new EventHandler(DeleteMenuItem_Click);

            contextMenu.Items.AddRange(new ToolStripItem[] { editMenuItem, addMenuItem, deleteMenuItem });

            dgv_inventory.ContextMenuStrip = contextMenu;
            dgv_inventory.MouseDown += new MouseEventHandler(dgv_inventory_MouseDown);
        }
        private void LoadTables()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();
                    DataTable dt = conn.GetSchema("Tables", new string[] { null, null, null, "BASE TABLE" });
                    foreach (DataRow row in dt.Rows)
                    {
                        cmb_tables.Items.Add(row["table_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                var logEntry = new log_Entry
                {
                    UserId = 0,
                    TableName = "table_name",
                    LogType = "ERROR",
                    LogMessage = "Помилка завантаження таблиць.",
                    Details = $"Tables ERROR "
                };
                logHelper.InsertLogEntry(logEntry);
                MessageBox.Show(ex.Message, "Ошибка загрузки таблиц", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadEquipmentData(string tableName)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();
                    string selectQuery = $"SELECT * FROM {tableName}";
                    using (var cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgv_inventory.DataSource = dt;
                            if (dgv_inventory.Columns.Contains("Id"))
                            {
                                dgv_inventory.Columns["Id"].Visible = false; // Скрываем столбец, но он остается доступным для обращения
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logEntry = new log_Entry
                {
                    UserId = 0,
                    TableName = tableName,
                    LogType = "ERROR",
                    LogMessage = "Помилка завантаження.",
                    Details = $"Equipment ERROR "
                };
                logHelper.InsertLogEntry(logEntry);
                MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchData(string tableName, string keyword)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();
                    string searchQuery = $"SELECT * FROM {tableName} WHERE " +
                                         $"CAST(Id AS TEXT) ILIKE @keyword OR " +
                                         $"inventorynumber ILIKE @keyword OR " +
                                         $"name ILIKE @keyword OR " +
                                         $"ip ILIKE @keyword OR " +
                                         $"mac ILIKE @keyword OR " +
                                         $"type ILIKE @keyword OR " +
                                         $"manufacturer ILIKE @keyword OR " +
                                         $"workerusername ILIKE @keyword OR " +  // Добавляем workerusername
                                         $"CAST(lastroutinemaintenancedate AS TEXT) ILIKE @keyword OR " +
                                         $"CAST(nextroutinemaintenancedate AS TEXT) ILIKE @keyword";
                    using (var cmd = new NpgsqlCommand(searchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgv_inventory.DataSource = dt;
                            if (dgv_inventory.Columns.Contains("Id"))
                            {
                                dgv_inventory.Columns["Id"].Visible = false; // Скрываем столбец, но он остается доступным для обращения
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка поиска данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_search.Text;
            string tableName = cmb_tables.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(tableName))
            {
                SearchData(tableName, keyword);
            }
        }
        private void cmb_tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEquipmentData(cmb_tables.SelectedItem.ToString());
        }
        private void dgv_inventory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgv_inventory.HitTest(e.X, e.Y);
                dgv_inventory.ClearSelection();
                if (hti.RowIndex >= 0)
                {
                    dgv_inventory.Rows[hti.RowIndex].Selected = true;
                }
            }
        }
        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_inventory.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgv_inventory.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(dgv_inventory.Rows[selectedRowIndex].Cells[0].Value); // Используем индекс столбца вместо имени
                frm_Add_Edit_Equipment editForm = new frm_Add_Edit_Equipment(selectedId);
                editForm.ShowDialog();
                LoadEquipmentData(cmb_tables.SelectedItem.ToString()); // Reload data
            }
        }
        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            frm_Add_Edit_Equipment addForm = new frm_Add_Edit_Equipment();
            addForm.ShowDialog();
            LoadEquipmentData(cmb_tables.SelectedItem.ToString()); // Reload data
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_inventory.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgv_inventory.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(dgv_inventory.Rows[selectedRowIndex].Cells[0].Value); // Используем индекс столбца вместо имени
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteRecord(selectedId);
                    LoadEquipmentData(cmb_tables.SelectedItem.ToString()); // Reload data
                }
            }
        }
        private void DeleteRecord(int id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Inventory")))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM equipment1 WHERE Id = @Id";
                    using (var cmd = new NpgsqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                var logEntry = new log_Entry
                {
                    UserId = 0,
                    TableName = "equipment1",
                    LogType = "INFO",
                    LogMessage = "Запис видалено успішно.",
                    Details = $"Delete Equipment "
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка удаления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_inventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
