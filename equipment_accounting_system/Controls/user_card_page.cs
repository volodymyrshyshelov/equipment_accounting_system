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
using equipment_accounting_system.Additional_Forms;

namespace equipment_accounting_system.Controls
{
    public partial class user_card_page : UserControl
    {
        private int userID;
        public user_card_page(int userID)
        {
            this.userID = userID;
            InitializeComponent();
            LoadUserData();
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
        }
       
        private void LoadUserData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("LogAndReg")))
                {
                    conn.Open();
                    string selectQuery = "SELECT * FROM UserList WHERE UserID = @userid";
                    using (var cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lbl_user_id.Text = userID.ToString();
                                lbl_fullname.Text = reader["FullName"].ToString();
                                lbl_username.Text = reader["Username"].ToString();

                                lbl_email.Text = reader["Email"].ToString();

                                lbl_bio.Text = reader["BIO"].ToString();


                                lbl_dept.Text = reader["Department"].ToString();
                                lbl_role.Text = reader["Role"].ToString();

                                if (reader["ProfileImage"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["ProfileImage"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        btn_user_image.Image = Image.FromStream(ms);
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
        private void btn_edit_Click(object sender, EventArgs e)
        {
            frm_Edit_User frm_Edit_User = new frm_Edit_User(userID);
            frm_Edit_User.ShowDialog();
        }
    }
}
