namespace equipment_accounting_system.Additional_Forms
{
    partial class frm_Dept_and_Roles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            label1 = new Label();
            lbl_DB_Tables = new Label();
            lstv_roles = new ListView();
            lstv_depts = new ListView();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            btn_cancel = new Guna.UI2.WinForms.Guna2TileButton();
            guna2GradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(btn_cancel);
            guna2GradientPanel1.Controls.Add(label1);
            guna2GradientPanel1.Controls.Add(lbl_DB_Tables);
            guna2GradientPanel1.Controls.Add(lstv_roles);
            guna2GradientPanel1.Controls.Add(lstv_depts);
            guna2GradientPanel1.CustomizableEdges = customizableEdges3;
            guna2GradientPanel1.Dock = DockStyle.Fill;
            guna2GradientPanel1.FillColor = Color.FromArgb(183, 54, 101);
            guna2GradientPanel1.FillColor2 = Color.FromArgb(29, 38, 113);
            guna2GradientPanel1.Location = new Point(0, 0);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GradientPanel1.Size = new Size(592, 397);
            guna2GradientPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(318, 33);
            label1.Name = "label1";
            label1.Size = new Size(119, 18);
            label1.TabIndex = 48;
            label1.Text = "Список посад";
            // 
            // lbl_DB_Tables
            // 
            lbl_DB_Tables.AutoSize = true;
            lbl_DB_Tables.BackColor = Color.Transparent;
            lbl_DB_Tables.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_DB_Tables.ForeColor = SystemColors.ControlLightLight;
            lbl_DB_Tables.Location = new Point(25, 33);
            lbl_DB_Tables.Name = "lbl_DB_Tables";
            lbl_DB_Tables.Size = new Size(126, 18);
            lbl_DB_Tables.TabIndex = 47;
            lbl_DB_Tables.Text = "Список відділів";
            // 
            // lstv_roles
            // 
            lstv_roles.BackColor = Color.FromArgb(35, 39, 112);
            lstv_roles.BackgroundImage = Properties.Resources.Screenshot_2024_05_15_191759;
            lstv_roles.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lstv_roles.ForeColor = SystemColors.Menu;
            lstv_roles.FullRowSelect = true;
            lstv_roles.Location = new Point(318, 54);
            lstv_roles.Name = "lstv_roles";
            lstv_roles.Size = new Size(250, 270);
            lstv_roles.TabIndex = 46;
            lstv_roles.UseCompatibleStateImageBehavior = false;
            lstv_roles.View = View.Details;
            lstv_roles.SelectedIndexChanged += lstv_roles_SelectedIndexChanged;
            // 
            // lstv_depts
            // 
            lstv_depts.BackColor = Color.FromArgb(35, 39, 112);
            lstv_depts.BackgroundImage = Properties.Resources.Screenshot_2024_05_15_191759;
            lstv_depts.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lstv_depts.ForeColor = SystemColors.Menu;
            lstv_depts.FullRowSelect = true;
            lstv_depts.Location = new Point(25, 54);
            lstv_depts.Name = "lstv_depts";
            lstv_depts.Size = new Size(250, 270);
            lstv_depts.TabIndex = 45;
            lstv_depts.UseCompatibleStateImageBehavior = false;
            lstv_depts.View = View.Details;
            lstv_depts.SelectedIndexChanged += lstv_depts_SelectedIndexChanged;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = guna2GradientPanel1;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Transparent;
            btn_cancel.BorderColor = Color.White;
            btn_cancel.BorderRadius = 20;
            btn_cancel.BorderThickness = 1;
            btn_cancel.CustomBorderColor = Color.White;
            btn_cancel.CustomizableEdges = customizableEdges1;
            btn_cancel.DisabledState.BorderColor = Color.DarkGray;
            btn_cancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_cancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_cancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_cancel.FillColor = Color.Transparent;
            btn_cancel.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(25, 330);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.PressedColor = Color.FromArgb(43, 39, 112);
            btn_cancel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_cancel.Size = new Size(543, 35);
            btn_cancel.TabIndex = 102;
            btn_cancel.Text = "Завершити редагування";
            btn_cancel.Click += btn_cancel_Click;
            // 
            // frm_Dept_and_Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 397);
            Controls.Add(guna2GradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Dept_and_Roles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frm_Dept_and_Roles";
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private ListView lstv_roles;
        private ListView lstv_depts;
        private Label label1;
        private Label lbl_DB_Tables;
        private Guna.UI2.WinForms.Guna2TileButton btn_cancel;
    }
}