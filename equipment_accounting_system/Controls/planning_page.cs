using equipment_accounting_system.Additional_Forms;
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
    public partial class planning_page : UserControl
    {
        public planning_page()
        {
            InitializeComponent();
            LoadPlans();
            InitializeComboBoxes();
            InitializePlanningContextMenu(); 
            dp_start_date.ValueChanged += new System.EventHandler(this.dp_start_date_ValueChanged);
            dp_end_date.ValueChanged += new System.EventHandler(this.dp_end_date_ValueChanged);
            cmb_plan_type.SelectedIndexChanged += new System.EventHandler(this.cmb_plan_type_SelectedIndexChanged);
            cmb_plan_priority.SelectedIndexChanged += new System.EventHandler(this.cmb_plan_priority_SelectedIndexChanged);
            InitializeDateTimePickers();
        }
        private void InitializeComboBoxes()
        {
            cmb_plan_type.Items.AddRange(new string[] { "Всі типи", "Ремонт", "Обслуговування", "Діагностика" });
            cmb_plan_priority.Items.AddRange(new string[] { "Всі пріорітети", "Низький", "Середній", "Високий", "Негайний" });

            cmb_plan_type.SelectedIndex = 0; 
            cmb_plan_priority.SelectedIndex = 0; 
        }
        private void dp_start_date_ValueChanged(object sender, EventArgs e)
        {
            LoadPlansWithFilters();
        }
        private void dp_end_date_ValueChanged(object sender, EventArgs e)
        {
            LoadPlansWithFilters();
        }
        private void cmb_plan_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlansWithFilters();
        }
        private void cmb_plan_priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlansWithFilters();
        }
        private void lst_plans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InitializeDateTimePickers()
        {
            
            dp_start_date.Format = DateTimePickerFormat.Custom;
            dp_start_date.CustomFormat = "dd-MM-yyyy";

            dp_end_date.Format = DateTimePickerFormat.Custom;
            dp_end_date.CustomFormat = "dd-MM-yyyy";
        }
        private void LoadPlans()
        {
            lst_plans.Items.Clear();

            string sql = "SELECT in_number, name, status, workername, priority, type, start_date, end_date, details FROM planning";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var item = new ListViewItem(dr["in_number"].ToString());
                                item.SubItems.Add(dr["name"].ToString());
                                item.SubItems.Add(dr["start_date"].ToString());
                                item.SubItems.Add(dr["end_date"].ToString());
                                item.SubItems.Add(dr["status"].ToString());
                                item.SubItems.Add(dr["type"].ToString());
                                item.SubItems.Add(dr["workername"].ToString());
                                item.SubItems.Add(dr["priority"].ToString());
                                lst_plans.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Task Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadPlansWithFilters()
        {
            lst_plans.Items.Clear();

            string sql = "SELECT in_number, name, status, workername, priority, type, start_date, end_date, details FROM planning WHERE 1=1";

            
            if (dp_start_date.Value != DateTime.MinValue && dp_end_date.Value != DateTime.MinValue)
            {
                sql += " AND start_date >= @startDate AND end_date <= @endDate";
            }

            
            if (cmb_plan_type.SelectedItem != null && cmb_plan_type.SelectedItem.ToString() != "Всі типи")
            {
                sql += " AND type = @type";
            }

            
            if (cmb_plan_priority.SelectedItem != null && cmb_plan_priority.SelectedItem.ToString() != "Всі пріорітети")
            {
                sql += " AND priority = @priority";
            }

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        
                        if (dp_start_date.Value != DateTime.MinValue && dp_end_date.Value != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@startDate", dp_start_date.Value);
                            cmd.Parameters.AddWithValue("@endDate", dp_end_date.Value);
                        }

                        
                        if (cmb_plan_type.SelectedItem != null && cmb_plan_type.SelectedItem.ToString() != "Всі типи")
                        {
                            cmd.Parameters.AddWithValue("@type", cmb_plan_type.SelectedItem.ToString());
                        }

                        
                        if (cmb_plan_priority.SelectedItem != null && cmb_plan_priority.SelectedItem.ToString() != "Всі пріорітети")
                        {
                            cmd.Parameters.AddWithValue("@priority", cmb_plan_priority.SelectedItem.ToString());
                        }

                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var item = new ListViewItem(dr["in_number"].ToString());
                                item.SubItems.Add(dr["name"].ToString());
                                item.SubItems.Add(dr["start_date"].ToString());
                                item.SubItems.Add(dr["end_date"].ToString());
                                item.SubItems.Add(dr["status"].ToString());
                                item.SubItems.Add(dr["type"].ToString());
                                item.SubItems.Add(dr["workername"].ToString());
                                item.SubItems.Add(dr["priority"].ToString());
                                lst_plans.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Task Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void InitializePlanningContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            var addTaskItem = new ToolStripMenuItem("Додати запис");
            var editTaskItem = new ToolStripMenuItem("Редагувати запис");
            var deleteTaskItem = new ToolStripMenuItem("Видалити запис");

            addTaskItem.Click += AddTask_Click;
            editTaskItem.Click += EditTask_Click;
            deleteTaskItem.Click += DeleteTask_Click;

            contextMenu.Items.Add(addTaskItem);
            contextMenu.Items.Add(editTaskItem);
            contextMenu.Items.Add(deleteTaskItem);

            lst_plans.ContextMenuStrip = contextMenu;
        }
        private void AddTask_Click(object sender, EventArgs e)
        {
            var addEditForm = new frm_Add_Edit_Plans();
            addEditForm.ShowDialog();
            LoadPlansWithFilters();
        }
        private void EditTask_Click(object sender, EventArgs e)
        {
            if (lst_plans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть запис для редагування.");
                return;
            }

            var selectedItem = lst_plans.SelectedItems[0];
            var inNumber = selectedItem.SubItems[0].Text;
            int planId = GetPlanIdByInNumber(inNumber);

            if (planId != 0)
            {
                var addEditForm = new frm_Add_Edit_Plans(planId);
                addEditForm.ShowDialog();
                LoadPlansWithFilters();
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
        private void DeleteTask_Click(object sender, EventArgs e)
        {
            if (lst_plans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть запис для видалення.");
                return;
            }

            var taskId = lst_plans.SelectedItems[0].Text;

            string sql = "DELETE FROM planning WHERE in_number = @in_number";

            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("Planning")))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@in_number", taskId);
                        cmd.ExecuteNonQuery();
                        LoadPlansWithFilters();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Delete Task Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
