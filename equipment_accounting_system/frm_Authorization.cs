using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;
using equipment_accounting_system.Additional_Forms;
using equipment_accounting_system.Classes;

namespace equipment_accounting_system
{
    public partial class frm_Authorization : Form
    {
        public frm_Authorization()
        {
            InitializeComponent();
        }

        private void frm_Authorization_Load(object sender, EventArgs e)
        {

        }
        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
        private void chb_show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_show_password.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';

            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Поля логіну та пароля пусті!", "Система обліку обладнання: Помилка Авторизації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string loginQuery = "SELECT userid, PasswordHash FROM UserList WHERE Username = @username";
                    using (var cmd = new NpgsqlCommand(loginQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txt_username.Text);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string storedPasswordHash = dr["PasswordHash"].ToString();

                                if (storedPasswordHash == txt_password.Text)
                                {
                                    
                                    int userID = Convert.ToInt32(dr["userid"]);
                                    frm_Dashboard dashboardForm = new frm_Dashboard(userID);
                                    dashboardForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    throw new Exception("Невірний пароль.");
                                }
                            }
                            else
                            {
                                throw new Exception("Невірний логін.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Система обліку обладнання: Помилка Авторизації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_password.Text = "";
                txt_username.Focus();
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_password.Text = "";
            txt_username.Focus();
        }
        private void link_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Registration registrationForm = new frm_Registration();
            registrationForm.Show();
            this.Hide();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
