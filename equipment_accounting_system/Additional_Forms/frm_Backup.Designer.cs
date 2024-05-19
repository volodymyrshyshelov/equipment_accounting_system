namespace equipment_accounting_system.Additional_Forms
{
    partial class frm_Backup
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            btn_cancel = new Guna.UI2.WinForms.Guna2TileButton();
            rb_restore = new Guna.UI2.WinForms.Guna2RadioButton();
            rb_backup = new Guna.UI2.WinForms.Guna2RadioButton();
            btn_save = new Guna.UI2.WinForms.Guna2TileButton();
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
            guna2GradientPanel1.Controls.Add(btn_save);
            guna2GradientPanel1.Controls.Add(btn_cancel);
            guna2GradientPanel1.Controls.Add(rb_restore);
            guna2GradientPanel1.Controls.Add(rb_backup);
            guna2GradientPanel1.CustomizableEdges = customizableEdges5;
            guna2GradientPanel1.Dock = DockStyle.Fill;
            guna2GradientPanel1.FillColor = Color.FromArgb(183, 54, 101);
            guna2GradientPanel1.FillColor2 = Color.FromArgb(29, 38, 113);
            guna2GradientPanel1.Location = new Point(0, 0);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GradientPanel1.Size = new Size(345, 103);
            guna2GradientPanel1.TabIndex = 0;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Transparent;
            btn_cancel.BorderColor = Color.White;
            btn_cancel.BorderRadius = 20;
            btn_cancel.BorderThickness = 1;
            btn_cancel.CustomBorderColor = Color.White;
            btn_cancel.CustomizableEdges = customizableEdges3;
            btn_cancel.DisabledState.BorderColor = Color.DarkGray;
            btn_cancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_cancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_cancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_cancel.FillColor = Color.Transparent;
            btn_cancel.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(175, 51);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.PressedColor = Color.FromArgb(43, 39, 112);
            btn_cancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_cancel.Size = new Size(157, 35);
            btn_cancel.TabIndex = 102;
            btn_cancel.Text = "Відміна";
            btn_cancel.Click += btn_cancel_Click;
            // 
            // rb_restore
            // 
            rb_restore.AutoSize = true;
            rb_restore.BackColor = Color.Transparent;
            rb_restore.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            rb_restore.CheckedState.BorderThickness = 0;
            rb_restore.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            rb_restore.CheckedState.InnerColor = Color.White;
            rb_restore.CheckedState.InnerOffset = -4;
            rb_restore.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rb_restore.ForeColor = SystemColors.HighlightText;
            rb_restore.Location = new Point(163, 12);
            rb_restore.Name = "rb_restore";
            rb_restore.Size = new Size(175, 22);
            rb_restore.TabIndex = 1;
            rb_restore.Text = "Завантажити копію";
            rb_restore.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rb_restore.UncheckedState.BorderThickness = 2;
            rb_restore.UncheckedState.FillColor = Color.Transparent;
            rb_restore.UncheckedState.InnerColor = Color.Transparent;
            rb_restore.UseVisualStyleBackColor = false;
            // 
            // rb_backup
            // 
            rb_backup.AutoSize = true;
            rb_backup.BackColor = Color.Transparent;
            rb_backup.Checked = true;
            rb_backup.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            rb_backup.CheckedState.BorderThickness = 0;
            rb_backup.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            rb_backup.CheckedState.InnerColor = Color.White;
            rb_backup.CheckedState.InnerOffset = -4;
            rb_backup.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rb_backup.ForeColor = SystemColors.HighlightText;
            rb_backup.Location = new Point(12, 12);
            rb_backup.Name = "rb_backup";
            rb_backup.Size = new Size(145, 22);
            rb_backup.TabIndex = 0;
            rb_backup.TabStop = true;
            rb_backup.Text = "Зберегти копію";
            rb_backup.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            rb_backup.UncheckedState.BorderThickness = 2;
            rb_backup.UncheckedState.FillColor = Color.Transparent;
            rb_backup.UncheckedState.InnerColor = Color.Transparent;
            rb_backup.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.Transparent;
            btn_save.BorderColor = Color.White;
            btn_save.BorderRadius = 20;
            btn_save.BorderThickness = 1;
            btn_save.CustomBorderColor = Color.White;
            btn_save.CustomizableEdges = customizableEdges1;
            btn_save.DisabledState.BorderColor = Color.DarkGray;
            btn_save.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_save.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_save.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_save.FillColor = Color.Transparent;
            btn_save.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_save.ForeColor = Color.White;
            btn_save.Location = new Point(12, 51);
            btn_save.Name = "btn_save";
            btn_save.PressedColor = Color.FromArgb(43, 39, 112);
            btn_save.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_save.Size = new Size(157, 35);
            btn_save.TabIndex = 103;
            btn_save.Text = "Виконати";
            btn_save.Click += btn_save_Click;
            // 
            // frm_Backup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 103);
            Controls.Add(guna2GradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frm_Backup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frm_Backup";
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2RadioButton rb_restore;
        private Guna.UI2.WinForms.Guna2RadioButton rb_backup;
        private Guna.UI2.WinForms.Guna2TileButton btn_cancel;
        private Guna.UI2.WinForms.Guna2TileButton btn_save;
    }
}