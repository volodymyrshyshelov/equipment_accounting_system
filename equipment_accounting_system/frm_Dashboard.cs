using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using equipment_accounting_system.Controls;
using equipment_accounting_system.Classes;
using equipment_accounting_system.Properties;
using Npgsql;
using System.Configuration;

namespace equipment_accounting_system
{
    public partial class frm_Dashboard : Form
    {
        private int userID;
        public frm_Dashboard(int userID)
        {
            this.userID = userID;
            InitializeComponent();
            home_page uc = new home_page(userID);
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
            LoadUserCardBackgroundImage();



        }

        private void btn_dashboard_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_dashboard_maximize_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void btn_dashboard_minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_dashboard_logout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frm_Authorization loginForm = new frm_Authorization();
            loginForm.Show();
        }
        private void gn_btn_menu_home_Click(object sender, EventArgs e)
        {
            home_page uc = new home_page(userID);
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }
        private void gn_btn_menu_inventory_Click(object sender, EventArgs e)
        {
            inventory_page uc = new inventory_page();
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }
        private void gn_btn_menu_scan_Click(object sender, EventArgs e)
        {
            scanning_page uc = new scanning_page();
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }
        private void gn_btn_menu_planing_Click(object sender, EventArgs e)
        {
            planning_page uc = new planning_page();
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }
        private void gn_btn_menu_reports_Click(object sender, EventArgs e)
        {
            report_page uc = new report_page();
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }
        private void gn_btn_menu_settings_Click(object sender, EventArgs e)
        {
            settings_page uc = new settings_page();
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }
        private void LoadUserCardBackgroundImage()
        {
            Image userImage = LoadUserImage(userID);
            if (userImage != null)
            {
                gn_btn_menu_user_card.BackgroundImage = userImage;
                /*gn_btn_menu_user_card.BackgroundImageLayout = ImageLayout.Stretch;*/ // Настроить ImageLayout по необходимости
            }
        }
        private Image LoadUserImage(int userID)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string selectQuery = "SELECT profileimage FROM UserList WHERE userid = @UserID";
                    using (var cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["profileimage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["profileimage"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    return Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        private void gn_btn_menu_user_card_Click(object sender, EventArgs e)
        {
            user_card_page uc = new user_card_page(userID);
            ui_Helper uiHelper = new ui_Helper();
            uiHelper.addControl(uc, pnl_container);
        }

        private void pnl_container_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
