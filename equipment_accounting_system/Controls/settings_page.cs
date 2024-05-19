using equipment_accounting_system.Additional_Forms;
using equipment_accounting_system.Classes;
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
    public partial class settings_page : UserControl
    {
        private db_Helper dbHelper;
        private string connectionString;
        public settings_page()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadSettings();
            dbHelper = new db_Helper();
            connectionString = ConfigurationManager.AppSettings.Get("Inventory");
            LoadTables();
            InitializeContextMenu();
        }
        private void LoadTables()
        {
            dbHelper.LoadTables(connectionString, lstv_tables);
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem addTableItem = new ToolStripMenuItem("Додати таблицю");
            ToolStripMenuItem deleteTableItem = new ToolStripMenuItem("Видалити таблицю");

            addTableItem.Click += new EventHandler(AddTableItem_Click);
            deleteTableItem.Click += new EventHandler(DeleteTableItem_Click);

            contextMenu.Items.Add(addTableItem);
            contextMenu.Items.Add(deleteTableItem);

            lstv_tables.ContextMenuStrip = contextMenu;
        }
        private void AddTableItem_Click(object sender, EventArgs e)
        {
            string tableName = Prompt.ShowDialog("Введіть назву нової таблиці", "Додати таблицю");
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                dbHelper.CreateTable(connectionString, tableName);
                LoadTables();
            }
        }

        private void DeleteTableItem_Click(object sender, EventArgs e)
        {
            if (lstv_tables.SelectedItems.Count > 0)
            {
                string tableName = lstv_tables.SelectedItems[0].Text;
                dbHelper.DropTable(connectionString, tableName);
                LoadTables();
            }
            else
            {
                MessageBox.Show("Виберіть таблицю для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeComboBoxes()
        {
            cmb_language.Items.AddRange(new string[] { "Українська", "English" });
            cmb_theme.Items.AddRange(new string[] { "Світла", "Темна" });

            cmb_language.SelectedIndexChanged += cmb_language_SelectedIndexChanged;
            cmb_theme.SelectedIndexChanged += cmb_theme_SelectedIndexChanged;
        }
        private void LoadSettings()
        {
            var currentLanguage = ConfigurationManager.AppSettings["Language"];
            var currentTheme = ConfigurationManager.AppSettings["Theme"];

            cmb_language.SelectedItem = currentLanguage;
            cmb_theme.SelectedItem = currentTheme;
        }
        private void lstv_tables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void cmb_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTheme = cmb_theme.SelectedItem.ToString();
            ChangeTheme(selectedTheme);
            SaveSetting("Theme", selectedTheme);
        }



        private void cmb_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLanguage = cmb_language.SelectedItem.ToString();
            ChangeLanguage(selectedLanguage);
            SaveSetting("Language", selectedLanguage);
        }
        private void ChangeLanguage(string language)
        {
            // 
            // 
            // 
        }

        private void ChangeTheme(string theme)
        {
            // 
            // 
            // 
        }
        private void SaveSetting(string key, string value)
        {

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btn_manage_dept_roles_Click(object sender, EventArgs e)
        {
            frm_Dept_and_Roles deptAndRolesForm = new frm_Dept_and_Roles();
            deptAndRolesForm.ShowDialog();
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            frm_Backup backupForm = new frm_Backup();
            backupForm.ShowDialog();
        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "OK", Left = 290, Width = 70, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }
}