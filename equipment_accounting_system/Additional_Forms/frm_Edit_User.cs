using equipment_accounting_system.Classes;
using equipment_accounting_system.Controls;
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
    public partial class frm_Edit_User : Form
    {
        private int userID;
        public frm_Edit_User(int userID)
        {

            this.userID = userID;
            InitializeComponent();
            LoadUserData();

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string updateQuery = "UPDATE UserList SET Username = @Username, FullName = @FullName, Email = @Email, Department = @Department, Role = @Role, BIO = @BIO, ProfileImage = @ProfileImage WHERE UserID = @UserID";
                    using (var cmd = new NpgsqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txt_username.Text);
                        cmd.Parameters.AddWithValue("@FullName", txt_real_name.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@Department", cmb_department.Text);
                        cmd.Parameters.AddWithValue("@Role", cmb_role.Text);
                        cmd.Parameters.AddWithValue("@BIO", txt_bio.Text);

                        if (btn_add_image.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Используйте формат изображения, который поддерживает вашу база данных (например, JPEG)
                                btn_add_image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                cmd.Parameters.AddWithValue("@ProfileImage", ms.ToArray());
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ProfileImage", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@UserID", userID);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Зміни збережено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void LoadUserData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string selectQuery = "SELECT * FROM UserList WHERE UserID = @UserID";
                    using (var cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_username.Text = reader["username"].ToString();
                                txt_real_name.Text = reader["fullname"].ToString();
                                txt_email.Text = reader["email"].ToString();
                                cmb_department.Text = reader["department"].ToString();
                                cmb_role.Text = reader["role"].ToString();
                                txt_bio.Text = reader["bio"].ToString();

                                if (reader["profileimage"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["profileimage"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        btn_add_image.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка завантаження даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}
