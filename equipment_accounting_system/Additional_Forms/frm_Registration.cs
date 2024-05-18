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
    public partial class frm_Registration : Form
    {
        public frm_Registration()
        {
            InitializeComponent();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_real_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_confirn_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    btn_add_image.Image = Image.FromFile(openFileDialog.FileName);

                }
            }
        }

        private void chb_show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_show_password.Checked)
            {
                txt_password.PasswordChar = '\0';
                txt_confirm_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
                txt_confirm_password.PasswordChar = '*';
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) || string.IsNullOrWhiteSpace(txt_confirm_password.Text) ||
            string.IsNullOrWhiteSpace(txt_email.Text))
            {
                MessageBox.Show("Заповніть обов'язкові поля!", "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_password.Text != txt_confirm_password.Text)
            {
                MessageBox.Show("Паролі не співпадають!", "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO UserList (Username, PasswordHash, Email, FullName, ProfileImage) VALUES (@Username, @PasswordHash, @Email, @FullName, @ProfileImage)";
                    using (var cmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txt_username.Text);
                        cmd.Parameters.AddWithValue("@PasswordHash", txt_password.Text); // Хеширование пароля должно быть добавлено здесь
                        cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@FullName", txt_real_name.Text);

                        if (btn_add_image.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                btn_add_image.Image.Save(ms, btn_add_image.Image.RawFormat);
                                cmd.Parameters.AddWithValue("@ProfileImage", ms.ToArray());
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ProfileImage", DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frm_Authorization frm_Authorization = new frm_Authorization();
                    frm_Authorization.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Authorization frm_Authorization = new frm_Authorization();
            frm_Authorization.Show();
        }
    }
}
