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
    public partial class report_page : UserControl
    {
        private readonly file_Export fileExport;
        public report_page()
        {
            InitializeComponent();
            fileExport = new file_Export();
            LoadReportTypes();
            cmb_type_1.SelectedIndexChanged += cmb_type_SelectedIndexChanged;
            cmb_type_2.SelectedIndexChanged += cmb_type_2_SelectedIndexChanged;
            cmb_type_3.SelectedIndexChanged += cmb_type_3_SelectedIndexChanged;
            dgv_reports.CellFormatting += dgv_reports_CellFormatting;
        }
        private void cmb_type_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmb_type_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmb_type_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData();
        }
        private void dgv_reports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_reports.Columns[e.ColumnIndex].Name == "eqimage" && e.Value != null)
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
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dgv_reports.DataSource == null)
            {
                MessageBox.Show("Спочатку завантажте дані для експорту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|PDF files (*.pdf)|*.pdf|JSON files (*.json)|*.json|CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Збереження звіту";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string extension = System.IO.Path.GetExtension(filePath).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".xlsx":
                                fileExport.ExportToExcel(dgv_reports, filePath);
                                break;
                            case ".pdf":
                                fileExport.ExportToPdf(dgv_reports, filePath);
                                break;
                            case ".json":
                                fileExport.ExportToJson(dgv_reports, filePath);
                                break;
                            case ".csv":
                                fileExport.ExportToCsv(dgv_reports, filePath);
                                break;
                            default:
                                throw new Exception("Непідтримуваний формат файлу.");
                        }

                        MessageBox.Show("Дані успішно експортовані!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка експорту даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void LoadReportTypes()
        {
            cmb_type_1.Items.AddRange(new string[] { "Отчеты по оборудованию", "Отчеты по задачам" });
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_type_2.Items.Clear();
            cmb_type_3.Items.Clear();
            dgv_reports.DataSource = null;

            if (cmb_type_1.SelectedItem.ToString() == "Отчеты по оборудованию")
            {
                LoadEquipmentFilters();
            }
            else if (cmb_type_1.SelectedItem.ToString() == "Отчеты по задачам")
            {
                LoadTaskFilters();
            }
        }

        private void LoadEquipmentFilters()
        {
            cmb_type_2.Items.AddRange(new string[] { "По типу оборудования", "По дате последнего обслуживания", "По ответственному пользователю" });

            cmb_type_2.SelectedIndexChanged += (s, e) =>
            {
                cmb_type_3.Items.Clear();
                if (cmb_type_2.SelectedItem.ToString() == "По типу оборудования")
                {
                    LoadDistinctValues("type", "equipment1", cmb_type_3, "Inventory");
                }
                else if (cmb_type_2.SelectedItem.ToString() == "По дате последнего обслуживания")
                {
                    LoadDistinctValues("lastroutinemaintenancedate", "equipment1", cmb_type_3, "Inventory");
                }
                else if (cmb_type_2.SelectedItem.ToString() == "По ответственному пользователю")
                {
                    LoadDistinctValues("workerusername", "equipment1", cmb_type_3, "Inventory");
                }
            };
        }

        private void LoadTaskFilters()
        {
            cmb_type_2.Items.AddRange(new string[] { "По типу задачи", "По приоритету", "По статусу задачи", "По ответственному пользователю" });

            cmb_type_2.SelectedIndexChanged += (s, e) =>
            {
                cmb_type_3.Items.Clear();
                if (cmb_type_2.SelectedItem.ToString() == "По типу задачи")
                {
                    LoadDistinctValues("type", "planning", cmb_type_3, "Planning");
                }
                else if (cmb_type_2.SelectedItem.ToString() == "По приоритету")
                {
                    LoadDistinctValues("priority", "planning", cmb_type_3, "Planning");
                }
                else if (cmb_type_2.SelectedItem.ToString() == "По статусу задачи")
                {
                    LoadDistinctValues("status", "planning", cmb_type_3, "Planning");
                }
                else if (cmb_type_2.SelectedItem.ToString() == "По ответственному пользователю")
                {
                    LoadDistinctValues("workername", "planning", cmb_type_3, "Planning");
                }
            };
        }

        private void LoadDistinctValues(string columnName, string tableName, ComboBox comboBox, string connectionStringKey)
        {
            string sql = $"SELECT DISTINCT {columnName} FROM {tableName}";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get(connectionStringKey)))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear();
                            while (dr.Read())
                            {
                                if (columnName == "lastroutinemaintenancedate" && dr[columnName] != DBNull.Value)
                                {
                                    comboBox.Items.Add(Convert.ToDateTime(dr[columnName]).ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    comboBox.Items.Add(dr[columnName].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження значень: {ex.Message}", "Помилка завантаження фільтрів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadReportData()
        {

            string selectedType1 = cmb_type_1.SelectedItem?.ToString();
            string selectedType2 = cmb_type_2.SelectedItem?.ToString();
            string selectedType3 = cmb_type_3.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedType1) || string.IsNullOrEmpty(selectedType2) || string.IsNullOrEmpty(selectedType3))
            {
                MessageBox.Show("Будь ласка, оберіть всі типи фільтрів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tableName = selectedType1 == "Отчеты по оборудованию" ? "equipment1" : "planning";
            string columnName = GetColumnName(selectedType2, tableName);
            string connectionStringKey = selectedType1 == "Отчеты по оборудованию" ? "Inventory" : "Planning";

            string sql;
            if (selectedType2 == "По дате последнего обслуживания")
            {
                sql = $"SELECT * FROM {tableName} WHERE {columnName} = @selectedValue::date";
            }
            else
            {
                sql = $"SELECT * FROM {tableName} WHERE {columnName} = @selectedValue";
            }

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get(connectionStringKey)))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        if (selectedType2 == "По дате последнего обслуживания")
                        {
                            cmd.Parameters.AddWithValue("@selectedValue", DateTime.Parse(selectedType3));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@selectedValue", selectedType3);
                        }

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dgv_reports.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка завантаження звіту", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetColumnName(string filterType, string tableName)
        {
            switch (filterType)
            {
                case "По типу оборудования":
                case "По типу задачи":
                    return "type";
                case "По дате последнего обслуживания":
                    return "lastroutinemaintenancedate";
                case "По ответственному пользователю":
                    return tableName == "equipment1" ? "workerusername" : "workername";
                case "По приоритету":
                    return "priority";
                case "По статусу задачи":
                    return "status";
                default:
                    throw new Exception("Невідомий тип фільтра.");
            }
        }

        private void dgv_reports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
   


