namespace equipment_accounting_system.Controls
{
    partial class user_card_page
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbl_fullname = new Label();
            pnl_user_card_page = new Guna.UI2.WinForms.Guna2GradientPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lbl_bio = new Label();
            lbl_create_date = new Label();
            lbl_dept = new Label();
            lbl_role = new Label();
            lbl_email = new Label();
            lbl_username = new Label();
            lbl_user_id = new Label();
            btn_user_image = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_edit = new Guna.UI2.WinForms.Guna2TileButton();
            pnl_user_card_page.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_fullname
            // 
            lbl_fullname.BackColor = Color.Transparent;
            lbl_fullname.Dock = DockStyle.Top;
            lbl_fullname.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_fullname.ForeColor = SystemColors.ControlLightLight;
            lbl_fullname.Location = new Point(341, 0);
            lbl_fullname.Name = "lbl_fullname";
            lbl_fullname.Size = new Size(637, 37);
            lbl_fullname.TabIndex = 1;
            lbl_fullname.Text = "Full Name";
            lbl_fullname.TextAlign = ContentAlignment.MiddleCenter;
     
            // 
            // pnl_user_card_page
            // 
            pnl_user_card_page.Controls.Add(guna2Panel1);
            pnl_user_card_page.CustomizableEdges = customizableEdges6;
            pnl_user_card_page.Dock = DockStyle.Fill;
            pnl_user_card_page.FillColor = Color.FromArgb(183, 54, 101);
            pnl_user_card_page.FillColor2 = Color.FromArgb(29, 38, 113);
            pnl_user_card_page.Location = new Point(0, 0);
            pnl_user_card_page.Name = "pnl_user_card_page";
            pnl_user_card_page.ShadowDecoration.CustomizableEdges = customizableEdges7;
            pnl_user_card_page.Size = new Size(1008, 546);
            pnl_user_card_page.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.White;
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(btn_edit);
            guna2Panel1.Controls.Add(lbl_bio);
            guna2Panel1.Controls.Add(lbl_create_date);
            guna2Panel1.Controls.Add(lbl_dept);
            guna2Panel1.Controls.Add(lbl_role);
            guna2Panel1.Controls.Add(lbl_email);
            guna2Panel1.Controls.Add(lbl_username);
            guna2Panel1.Controls.Add(lbl_user_id);
            guna2Panel1.Controls.Add(lbl_fullname);
            guna2Panel1.Controls.Add(btn_user_image);
            guna2Panel1.CustomizableEdges = customizableEdges4;
            guna2Panel1.Location = new Point(15, 14);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Panel1.Size = new Size(978, 516);
            guna2Panel1.TabIndex = 2;
            // 
            // lbl_bio
            // 
            lbl_bio.BackColor = Color.Transparent;
            lbl_bio.Dock = DockStyle.Top;
            lbl_bio.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_bio.ForeColor = SystemColors.ControlLightLight;
            lbl_bio.Location = new Point(341, 169);
            lbl_bio.Name = "lbl_bio";
            lbl_bio.Size = new Size(637, 285);
            lbl_bio.TabIndex = 7;
            lbl_bio.Text = "Biograhpy";
            lbl_bio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_create_date
            // 
            lbl_create_date.BackColor = Color.Transparent;
            lbl_create_date.Dock = DockStyle.Top;
            lbl_create_date.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_create_date.ForeColor = SystemColors.ControlLightLight;
            lbl_create_date.Location = new Point(341, 147);
            lbl_create_date.Name = "lbl_create_date";
            lbl_create_date.Size = new Size(637, 22);
            lbl_create_date.TabIndex = 6;
            lbl_create_date.Text = "Create Date";
            lbl_create_date.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_dept
            // 
            lbl_dept.BackColor = Color.Transparent;
            lbl_dept.Dock = DockStyle.Top;
            lbl_dept.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_dept.ForeColor = SystemColors.ControlLightLight;
            lbl_dept.Location = new Point(341, 125);
            lbl_dept.Name = "lbl_dept";
            lbl_dept.Size = new Size(637, 22);
            lbl_dept.TabIndex = 5;
            lbl_dept.Text = "Departament";
            lbl_dept.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_role
            // 
            lbl_role.BackColor = Color.Transparent;
            lbl_role.Dock = DockStyle.Top;
            lbl_role.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_role.ForeColor = SystemColors.ControlLightLight;
            lbl_role.Location = new Point(341, 103);
            lbl_role.Name = "lbl_role";
            lbl_role.Size = new Size(637, 22);
            lbl_role.TabIndex = 4;
            lbl_role.Text = "Role";
            lbl_role.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_email
            // 
            lbl_email.BackColor = Color.Transparent;
            lbl_email.Dock = DockStyle.Top;
            lbl_email.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_email.ForeColor = SystemColors.ControlLightLight;
            lbl_email.Location = new Point(341, 81);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(637, 22);
            lbl_email.TabIndex = 3;
            lbl_email.Text = "email";
            lbl_email.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_username
            // 
            lbl_username.BackColor = Color.Transparent;
            lbl_username.Dock = DockStyle.Top;
            lbl_username.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_username.ForeColor = SystemColors.ControlLightLight;
            lbl_username.Location = new Point(341, 59);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(637, 22);
            lbl_username.TabIndex = 8;
            lbl_username.Text = "Username";
            lbl_username.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_user_id
            // 
            lbl_user_id.BackColor = Color.Transparent;
            lbl_user_id.Dock = DockStyle.Top;
            lbl_user_id.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_user_id.ForeColor = SystemColors.ControlLightLight;
            lbl_user_id.Location = new Point(341, 37);
            lbl_user_id.Name = "lbl_user_id";
            lbl_user_id.Size = new Size(637, 22);
            lbl_user_id.TabIndex = 2;
            lbl_user_id.Text = "ID";
            lbl_user_id.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_user_image
            // 
            btn_user_image.BackColor = Color.Transparent;
            btn_user_image.CheckedState.ImageSize = new Size(64, 64);
            btn_user_image.Dock = DockStyle.Left;
            btn_user_image.HoverState.ImageSize = new Size(200, 200);
            btn_user_image.Image = Properties.Resources.add1;
            btn_user_image.ImageOffset = new Point(0, 0);
            btn_user_image.ImageRotate = 0F;
            btn_user_image.ImageSize = new Size(200, 200);
            btn_user_image.Location = new Point(0, 0);
            btn_user_image.Name = "btn_user_image";
            btn_user_image.PressedState.ImageSize = new Size(64, 64);
            btn_user_image.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btn_user_image.Size = new Size(341, 516);
            btn_user_image.TabIndex = 0;
            btn_user_image.UseTransparentBackground = true;

            // 
            // btn_edit
            // 
            btn_edit.BackColor = Color.Transparent;
            btn_edit.BorderColor = Color.White;
            btn_edit.BorderRadius = 20;
            btn_edit.BorderThickness = 1;
            btn_edit.CustomBorderColor = Color.White;
            btn_edit.CustomizableEdges = customizableEdges1;
            btn_edit.DisabledState.BorderColor = Color.DarkGray;
            btn_edit.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_edit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_edit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_edit.FillColor = Color.Transparent;
            btn_edit.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_edit.ForeColor = Color.White;
            btn_edit.Location = new Point(512, 457);
            btn_edit.MinimumSize = new Size(300, 35);
            btn_edit.Name = "btn_edit";
            btn_edit.PressedColor = Color.FromArgb(43, 39, 112);
            btn_edit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_edit.Size = new Size(300, 35);
            btn_edit.TabIndex = 68;
            btn_edit.Text = "Змінити особисті дані";
            btn_edit.Click += btn_edit_Click;
            // 
            // user_card_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl_user_card_page);
            Name = "user_card_page";
            Size = new Size(1008, 546);
            pnl_user_card_page.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnl_user_card_page;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton btn_user_image;
        private Label lbl_fullname;
        private Label lbl_user_id;
        private Label lbl_create_date;
        private Label lbl_dept;
        private Label lbl_role;
        private Label lbl_email;
        private Label lbl_bio;
        private Label lbl_username;
        private Guna.UI2.WinForms.Guna2TileButton btn_edit;
    }
}
