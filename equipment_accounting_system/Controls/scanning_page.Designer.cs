namespace equipment_accounting_system.Controls
{
    partial class scanning_page
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnl_scanning_page = new Guna.UI2.WinForms.Guna2GradientPanel();
            lstvw_Scan = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            panel1 = new Panel();
            panel2 = new Panel();
            lbl_Scan_Status = new Label();
            btn_Start_Scan = new Guna.UI2.WinForms.Guna2TileButton();
            pnl_scanning_page.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_scanning_page
            // 
            pnl_scanning_page.Controls.Add(lstvw_Scan);
            pnl_scanning_page.Controls.Add(panel1);
            pnl_scanning_page.CustomizableEdges = customizableEdges3;
            pnl_scanning_page.Dock = DockStyle.Fill;
            pnl_scanning_page.FillColor = Color.FromArgb(183, 54, 101);
            pnl_scanning_page.FillColor2 = Color.FromArgb(29, 38, 113);
            pnl_scanning_page.Location = new Point(0, 0);
            pnl_scanning_page.Name = "pnl_scanning_page";
            pnl_scanning_page.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnl_scanning_page.Size = new Size(1008, 546);
            pnl_scanning_page.TabIndex = 1;
            // 
            // lstvw_Scan
            // 
            lstvw_Scan.Alignment = ListViewAlignment.Default;
            lstvw_Scan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstvw_Scan.BackColor = Color.FromArgb(181, 54, 101);
            lstvw_Scan.BackgroundImage = Properties.Resources.Screenshot_2024_05_15_191759;
            lstvw_Scan.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            lstvw_Scan.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lstvw_Scan.ForeColor = SystemColors.Menu;
            lstvw_Scan.FullRowSelect = true;
            lstvw_Scan.GridLines = true;
            lstvw_Scan.Location = new Point(9, 49);
            lstvw_Scan.Margin = new Padding(0);
            lstvw_Scan.Name = "lstvw_Scan";
            lstvw_Scan.Size = new Size(985, 485);
            lstvw_Scan.TabIndex = 9;
            lstvw_Scan.UseCompatibleStateImageBehavior = false;
            lstvw_Scan.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Ім`я в мережі";
            columnHeader1.Width = 190;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "IP адреса";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "MAC адреса";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Тип";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 125;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Виробник";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 195;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Є у БД";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 85;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 46);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(lbl_Scan_Status);
            panel2.Controls.Add(btn_Start_Scan);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(639, 46);
            panel2.TabIndex = 1;
            // 
            // lbl_Scan_Status
            // 
            lbl_Scan_Status.AutoSize = true;
            lbl_Scan_Status.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Scan_Status.ForeColor = SystemColors.Window;
            lbl_Scan_Status.Location = new Point(219, 12);
            lbl_Scan_Status.Name = "lbl_Scan_Status";
            lbl_Scan_Status.Size = new Size(168, 20);
            lbl_Scan_Status.TabIndex = 1;
            lbl_Scan_Status.Text = "Статус сканування";
            // 
            // btn_Start_Scan
            // 
            btn_Start_Scan.BorderColor = Color.White;
            btn_Start_Scan.BorderRadius = 20;
            btn_Start_Scan.BorderThickness = 1;
            btn_Start_Scan.CustomBorderColor = Color.White;
            btn_Start_Scan.CustomizableEdges = customizableEdges1;
            btn_Start_Scan.DisabledState.BorderColor = Color.DarkGray;
            btn_Start_Scan.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Start_Scan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Start_Scan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Start_Scan.FillColor = Color.Transparent;
            btn_Start_Scan.FocusedColor = Color.FromArgb(35, 39, 112);
            btn_Start_Scan.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Start_Scan.ForeColor = Color.White;
            btn_Start_Scan.Location = new Point(9, 4);
            btn_Start_Scan.Name = "btn_Start_Scan";
            btn_Start_Scan.PressedColor = Color.FromArgb(35, 39, 112);
            btn_Start_Scan.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Start_Scan.Size = new Size(204, 35);
            btn_Start_Scan.TabIndex = 0;
            btn_Start_Scan.Text = "Сканувати мережу";
            btn_Start_Scan.Click += btn_Start_Scan_Click_1;
            // 
            // scanning_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl_scanning_page);
            Name = "scanning_page";
            Size = new Size(1008, 546);
            pnl_scanning_page.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnl_scanning_page;
        private Panel panel1;
        private Panel panel2;
        private Label lbl_Scan_Status;
        private Guna.UI2.WinForms.Guna2TileButton btn_Start_Scan;
        private ListView lstvw_Scan;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}
