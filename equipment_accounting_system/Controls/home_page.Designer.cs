namespace equipment_accounting_system.Controls
{
    partial class home_page
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
            Label lblTotal;
            Label label3;
            Label label4;
            Label label5;
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblUserEquipmentCount = new Label();
            pnl_home_page = new Guna.UI2.WinForms.Guna2GradientPanel();
            guna2CustomGradientPanel3 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            listViewUserTasks = new ListView();
            guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            infographicPanel = new Guna.UI2.WinForms.Guna2Panel();
            lblTotalEquipment = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            listViewUserEquipment = new ListView();
            lblTotal = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pnl_home_page.SuspendLayout();
            guna2CustomGradientPanel3.SuspendLayout();
            guna2CustomGradientPanel2.SuspendLayout();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Top;
            lblTotal.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(0, 0);
            lblTotal.Margin = new Padding(3, 10, 3, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Padding = new Padding(0, 10, 0, 0);
            lblTotal.Size = new Size(302, 60);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Усього обладнання на підприємстві:";
            lblTotal.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 338);
            label3.Margin = new Padding(3, 10, 3, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 10, 0, 0);
            label3.Size = new Size(302, 38);
            label3.TabIndex = 4;
            label3.Text = "Закріплено за Вами: ";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(3, 10, 3, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 10, 0, 0);
            label4.Size = new Size(302, 60);
            label4.TabIndex = 2;
            label4.Text = "Обладнання, що за Вами закріплене ";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(3, 10, 3, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 10, 0, 0);
            label5.Size = new Size(302, 40);
            label5.TabIndex = 3;
            label5.Text = "Роспорядження на сьогодні";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblUserEquipmentCount
            // 
            lblUserEquipmentCount.Dock = DockStyle.Bottom;
            lblUserEquipmentCount.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUserEquipmentCount.Location = new Point(0, 376);
            lblUserEquipmentCount.Margin = new Padding(3, 10, 3, 0);
            lblUserEquipmentCount.Name = "lblUserEquipmentCount";
            lblUserEquipmentCount.Padding = new Padding(0, 10, 0, 0);
            lblUserEquipmentCount.Size = new Size(302, 38);
            lblUserEquipmentCount.TabIndex = 3;
            lblUserEquipmentCount.Text = "@Count@";
            lblUserEquipmentCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnl_home_page
            // 
            pnl_home_page.AutoSize = true;
            pnl_home_page.Controls.Add(guna2CustomGradientPanel3);
            pnl_home_page.Controls.Add(guna2CustomGradientPanel2);
            pnl_home_page.Controls.Add(panel2);
            pnl_home_page.Controls.Add(panel1);
            pnl_home_page.Controls.Add(guna2CustomGradientPanel1);
            pnl_home_page.CustomizableEdges = customizableEdges19;
            pnl_home_page.Dock = DockStyle.Fill;
            pnl_home_page.FillColor = Color.FromArgb(175, 53, 102);
            pnl_home_page.FillColor2 = Color.FromArgb(29, 38, 113);
            pnl_home_page.Location = new Point(0, 0);
            pnl_home_page.Name = "pnl_home_page";
            pnl_home_page.ShadowDecoration.CustomizableEdges = customizableEdges20;
            pnl_home_page.Size = new Size(1008, 546);
            pnl_home_page.TabIndex = 0;
            // 
            // guna2CustomGradientPanel3
            // 
            guna2CustomGradientPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2CustomGradientPanel3.AutoScroll = true;
            guna2CustomGradientPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2CustomGradientPanel3.BackColor = Color.Transparent;
            guna2CustomGradientPanel3.BorderColor = Color.FromArgb(37, 39, 112);
            guna2CustomGradientPanel3.BorderRadius = 20;
            guna2CustomGradientPanel3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            guna2CustomGradientPanel3.BorderThickness = 2;
            guna2CustomGradientPanel3.Controls.Add(listViewUserTasks);
            guna2CustomGradientPanel3.Controls.Add(label5);
            guna2CustomGradientPanel3.CustomizableEdges = customizableEdges11;
            guna2CustomGradientPanel3.FillColor = Color.FromArgb(173, 53, 102);
            guna2CustomGradientPanel3.FillColor2 = Color.Transparent;
            guna2CustomGradientPanel3.FillColor3 = Color.Transparent;
            guna2CustomGradientPanel3.FillColor4 = Color.FromArgb(37, 39, 112);
            guna2CustomGradientPanel3.ForeColor = SystemColors.Control;
            guna2CustomGradientPanel3.Location = new Point(689, 66);
            guna2CustomGradientPanel3.MaximumSize = new Size(800, 900);
            guna2CustomGradientPanel3.MinimumSize = new Size(302, 414);
            guna2CustomGradientPanel3.Name = "guna2CustomGradientPanel3";
            guna2CustomGradientPanel3.Quality = 125;
            guna2CustomGradientPanel3.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2CustomGradientPanel3.Size = new Size(302, 414);
            guna2CustomGradientPanel3.TabIndex = 1;
            // 
            // listViewUserTasks
            // 
            listViewUserTasks.BackColor = Color.Black;
            listViewUserTasks.BackgroundImage = Properties.Resources.Screenshot_2024_05_15_005912;
            listViewUserTasks.BorderStyle = BorderStyle.None;
            listViewUserTasks.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            listViewUserTasks.ForeColor = SystemColors.MenuText;
            listViewUserTasks.Location = new Point(8, 54);
            listViewUserTasks.Margin = new Padding(30);
            listViewUserTasks.Name = "listViewUserTasks";
            listViewUserTasks.Size = new Size(285, 281);
            listViewUserTasks.TabIndex = 4;
            listViewUserTasks.UseCompatibleStateImageBehavior = false;
            
            // 
            // guna2CustomGradientPanel2
            // 
            guna2CustomGradientPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2CustomGradientPanel2.AutoScroll = true;
            guna2CustomGradientPanel2.AutoSize = true;
            guna2CustomGradientPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2CustomGradientPanel2.BackColor = Color.Transparent;
            guna2CustomGradientPanel2.BorderColor = Color.FromArgb(37, 39, 112);
            guna2CustomGradientPanel2.BorderRadius = 20;
            guna2CustomGradientPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            guna2CustomGradientPanel2.BorderThickness = 2;
            guna2CustomGradientPanel2.Controls.Add(label3);
            guna2CustomGradientPanel2.Controls.Add(lblUserEquipmentCount);
            guna2CustomGradientPanel2.Controls.Add(infographicPanel);
            guna2CustomGradientPanel2.Controls.Add(lblTotalEquipment);
            guna2CustomGradientPanel2.Controls.Add(lblTotal);
            guna2CustomGradientPanel2.CustomizableEdges = customizableEdges15;
            guna2CustomGradientPanel2.FillColor = Color.FromArgb(173, 53, 102);
            guna2CustomGradientPanel2.FillColor2 = Color.Transparent;
            guna2CustomGradientPanel2.FillColor3 = Color.Transparent;
            guna2CustomGradientPanel2.FillColor4 = Color.FromArgb(37, 39, 112);
            guna2CustomGradientPanel2.ForeColor = SystemColors.Control;
            guna2CustomGradientPanel2.Location = new Point(352, 66);
            guna2CustomGradientPanel2.MaximumSize = new Size(800, 900);
            guna2CustomGradientPanel2.MinimumSize = new Size(302, 414);
            guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            guna2CustomGradientPanel2.Quality = 125;
            guna2CustomGradientPanel2.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2CustomGradientPanel2.Size = new Size(302, 414);
            guna2CustomGradientPanel2.TabIndex = 1;
            // 
            // infographicPanel
            // 
            infographicPanel.BackColor = Color.Transparent;
            infographicPanel.BorderColor = Color.FromArgb(64, 0, 64);
            infographicPanel.BorderRadius = 25;
            infographicPanel.BorderThickness = 1;
            infographicPanel.CustomizableEdges = customizableEdges13;
            infographicPanel.Location = new Point(15, 103);
            infographicPanel.MinimumSize = new Size(150, 150);
            infographicPanel.Name = "infographicPanel";
            infographicPanel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            infographicPanel.Size = new Size(273, 150);
            infographicPanel.TabIndex = 0;
            infographicPanel.Paint += chart_Paint;
            // 
            // lblTotalEquipment
            // 
            lblTotalEquipment.Dock = DockStyle.Top;
            lblTotalEquipment.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEquipment.Location = new Point(0, 60);
            lblTotalEquipment.Margin = new Padding(3, 10, 3, 0);
            lblTotalEquipment.Name = "lblTotalEquipment";
            lblTotalEquipment.Padding = new Padding(0, 10, 0, 0);
            lblTotalEquipment.Size = new Size(302, 38);
            lblTotalEquipment.TabIndex = 5;
            lblTotalEquipment.Text = "@Count@";
            lblTotalEquipment.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.BackColor = Color.Transparent;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.MinimumSize = new Size(1008, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(1008, 60);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 486);
            panel1.MinimumSize = new Size(1008, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 60);
            panel1.TabIndex = 1;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2CustomGradientPanel1.AutoScroll = true;
            guna2CustomGradientPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2CustomGradientPanel1.BackColor = Color.Transparent;
            guna2CustomGradientPanel1.BorderColor = Color.FromArgb(37, 39, 112);
            guna2CustomGradientPanel1.BorderRadius = 20;
            guna2CustomGradientPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            guna2CustomGradientPanel1.BorderThickness = 2;
            guna2CustomGradientPanel1.Controls.Add(listViewUserEquipment);
            guna2CustomGradientPanel1.Controls.Add(label4);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges17;
            guna2CustomGradientPanel1.FillColor = Color.FromArgb(173, 53, 102);
            guna2CustomGradientPanel1.FillColor2 = Color.Transparent;
            guna2CustomGradientPanel1.FillColor3 = Color.Transparent;
            guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(37, 39, 112);
            guna2CustomGradientPanel1.ForeColor = SystemColors.Control;
            guna2CustomGradientPanel1.Location = new Point(15, 66);
            guna2CustomGradientPanel1.MaximumSize = new Size(800, 900);
            guna2CustomGradientPanel1.MinimumSize = new Size(302, 414);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.Quality = 125;
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges18;
            guna2CustomGradientPanel1.Size = new Size(302, 414);
            guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // listViewUserEquipment
            // 
            listViewUserEquipment.BackColor = Color.FromArgb(149, 50, 104);
            listViewUserEquipment.BackgroundImage = Properties.Resources.Screenshot_2024_05_15_005447;
            listViewUserEquipment.BorderStyle = BorderStyle.None;
            listViewUserEquipment.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            listViewUserEquipment.ForeColor = SystemColors.MenuBar;
            listViewUserEquipment.Location = new Point(8, 54);
            listViewUserEquipment.Margin = new Padding(30);
            listViewUserEquipment.Name = "listViewUserEquipment";
            listViewUserEquipment.Size = new Size(285, 281);
            listViewUserEquipment.TabIndex = 3;
            listViewUserEquipment.UseCompatibleStateImageBehavior = false;
            listViewUserEquipment.View = View.List;
            // 
            // home_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl_home_page);
            Name = "home_page";
            Size = new Size(1008, 546);
            pnl_home_page.ResumeLayout(false);
            pnl_home_page.PerformLayout();
            guna2CustomGradientPanel3.ResumeLayout(false);
            guna2CustomGradientPanel2.ResumeLayout(false);
            guna2CustomGradientPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnl_home_page;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel3;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Panel panel2;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel infographicPanel;
        private ListView listViewUserTasks;
        private ListView listViewUserEquipment;
        private Label lblUserEquipmentCount;
        private Label lblTotalEquipment;
    }
}
