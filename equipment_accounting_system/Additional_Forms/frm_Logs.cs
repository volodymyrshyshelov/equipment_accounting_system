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
    public partial class frm_Logs : Form
    {
        private readonly file_Export fileExporter;
        public frm_Logs()
        {
            InitializeComponent();
            fileExporter = new file_Export();
            LoadComboBoxData();
            LoadLogsData();
        }
        private void LoadComboBoxData()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("LogConnection");
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Load log types
                string logTypeQuery = "SELECT DISTINCT log_type FROM logs";
                using (var cmd = new NpgsqlCommand(logTypeQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmb_types.Items.Add(reader["log_type"].ToString());
                    }
                }

                // Load table names
                string tableNameQuery = "SELECT DISTINCT table_name FROM logs";
                using (var cmd = new NpgsqlCommand(tableNameQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmb_table_name.Items.Add(reader["table_name"].ToString());
                    }
                }

                // Load user IDs
                string userIdQuery = "SELECT DISTINCT user_id FROM logs";
                using (var cmd = new NpgsqlCommand(userIdQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmb_user_id.Items.Add(reader["user_id"].ToString());
                    }
                }
            }
        }

        private void LoadLogsData()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("LogConnection");
            string query = "SELECT * FROM logs WHERE 1=1";

            if (cmb_types.SelectedItem != null && !string.IsNullOrEmpty(cmb_types.SelectedItem.ToString()))
            {
                query += " AND log_type = @log_type";
            }

            if (cmb_table_name.SelectedItem != null && !string.IsNullOrEmpty(cmb_table_name.SelectedItem.ToString()))
            {
                query += " AND table_name = @table_name";
            }

            if (cmb_user_id.SelectedItem != null && !string.IsNullOrEmpty(cmb_user_id.SelectedItem.ToString()))
            {
                query += " AND user_id = @user_id";
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (cmb_types.SelectedItem != null && !string.IsNullOrEmpty(cmb_types.SelectedItem.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@log_type", cmb_types.SelectedItem.ToString());
                    }

                    if (cmb_table_name.SelectedItem != null && !string.IsNullOrEmpty(cmb_table_name.SelectedItem.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@table_name", cmb_table_name.SelectedItem.ToString());
                    }

                    if (cmb_user_id.SelectedItem != null && !string.IsNullOrEmpty(cmb_user_id.SelectedItem.ToString()))
                    {
                        cmd.Parameters.AddWithValue("@user_id", cmb_user_id.SelectedItem.ToString());
                    }

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_logs.DataSource = dt;
                    }
                }
            }
        }


        private void cmb_user_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLogsData();
        }

        private void cmb_table_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLogsData();
        }

        private void cmb_types_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLogsData();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx|PDF Files|*.pdf|JSON Files|*.json|CSV Files|*.csv";
                sfd.Title = "Save an Export File";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(sfd.FileName);
                    switch (extension.ToLower())
                    {
                        case ".xlsx":
                            fileExporter.ExportToExcel(dgv_logs, sfd.FileName);
                            break;
                        case ".pdf":
                            fileExporter.ExportToPdf(dgv_logs, sfd.FileName);
                            break;
                        case ".json":
                            fileExporter.ExportToJson(dgv_logs, sfd.FileName);
                            break;
                        case ".csv":
                            fileExporter.ExportToCsv(dgv_logs, sfd.FileName);
                            break;
                        default:
                            MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    MessageBox.Show("File exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
