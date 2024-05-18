namespace equipment_accounting_system.Controls
{
    partial class inventory_page
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnl_inventory_page = new Guna.UI2.WinForms.Guna2GradientPanel();
            dgv_inventory = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            txt_search = new Guna.UI2.WinForms.Guna2TextBox();
            cmb_tables = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            pnl_inventory_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_inventory).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_inventory_page
            // 
            pnl_inventory_page.Controls.Add(dgv_inventory);
            pnl_inventory_page.Controls.Add(guna2Panel1);
            pnl_inventory_page.CustomizableEdges = customizableEdges7;
            pnl_inventory_page.Dock = DockStyle.Fill;
            pnl_inventory_page.FillColor = Color.FromArgb(175, 53, 102);
            pnl_inventory_page.FillColor2 = Color.FromArgb(29, 38, 113);
            pnl_inventory_page.Location = new Point(0, 0);
            pnl_inventory_page.Name = "pnl_inventory_page";
            pnl_inventory_page.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnl_inventory_page.Size = new Size(1008, 546);
            pnl_inventory_page.TabIndex = 1;
            // 
            // dgv_inventory
            // 
            dgv_inventory.AllowUserToAddRows = false;
            dgv_inventory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(175, 53, 102);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgv_inventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_inventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_inventory.BackgroundColor = Color.FromArgb(72, 43, 110);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(72, 43, 110);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(72, 43, 110);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_inventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_inventory.ColumnHeadersHeight = 30;
            dgv_inventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(100, 46, 108);
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(175, 53, 102);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_inventory.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_inventory.Dock = DockStyle.Fill;
            dgv_inventory.EditMode = DataGridViewEditMode.EditOnF2;
            dgv_inventory.GridColor = Color.FromArgb(231, 229, 255);
            dgv_inventory.Location = new Point(0, 43);
            dgv_inventory.MultiSelect = false;
            dgv_inventory.Name = "dgv_inventory";
            dgv_inventory.ReadOnly = true;
            dgv_inventory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(100, 46, 108);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(100, 46, 108);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_inventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_inventory.RowHeadersVisible = false;
            dgv_inventory.RowTemplate.Height = 25;
            dgv_inventory.Size = new Size(1008, 503);
            dgv_inventory.TabIndex = 2;
            dgv_inventory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(175, 53, 102);
            dgv_inventory.ThemeStyle.AlternatingRowsStyle.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dgv_inventory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.White;
            dgv_inventory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(175, 53, 102);
            dgv_inventory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.White;
            dgv_inventory.ThemeStyle.BackColor = Color.FromArgb(72, 43, 110);
            dgv_inventory.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgv_inventory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(72, 43, 110);
            dgv_inventory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_inventory.ThemeStyle.HeaderStyle.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dgv_inventory.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv_inventory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_inventory.ThemeStyle.HeaderStyle.Height = 30;
            dgv_inventory.ThemeStyle.ReadOnly = true;
            dgv_inventory.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(100, 46, 108);
            dgv_inventory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_inventory.ThemeStyle.RowsStyle.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dgv_inventory.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgv_inventory.ThemeStyle.RowsStyle.Height = 25;
            dgv_inventory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(175, 53, 102);
            dgv_inventory.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.Controls.Add(txt_search);
            guna2Panel1.Controls.Add(cmb_tables);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1008, 43);
            guna2Panel1.TabIndex = 1;
            // 
            // txt_search
            // 
            txt_search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txt_search.BackColor = Color.Transparent;
            txt_search.BorderRadius = 20;
            txt_search.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txt_search.CustomizableEdges = customizableEdges1;
            txt_search.DefaultText = "Пошук";
            txt_search.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_search.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_search.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_search.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_search.FillColor = Color.FromArgb(77, 43, 110);
            txt_search.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_search.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txt_search.ForeColor = Color.White;
            txt_search.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_search.IconRight = Properties.Resources.loupe;
            txt_search.IconRightCursor = Cursors.Hand;
            txt_search.IconRightSize = new Size(30, 30);
            txt_search.Location = new Point(3, 3);
            txt_search.Name = "txt_search";
            txt_search.PasswordChar = '\0';
            txt_search.PlaceholderForeColor = Color.Transparent;
            txt_search.PlaceholderText = "";
            txt_search.SelectedText = "";
            txt_search.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txt_search.Size = new Size(250, 36);
            txt_search.TabIndex = 2;
            txt_search.TextAlign = HorizontalAlignment.Center;
            txt_search.TextChanged += txt_search_TextChanged;
            // 
            // cmb_tables
            // 
            cmb_tables.AutoRoundedCorners = true;
            cmb_tables.BackColor = Color.Transparent;
            cmb_tables.BorderColor = Color.Transparent;
            cmb_tables.BorderRadius = 17;
            cmb_tables.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            cmb_tables.CustomizableEdges = customizableEdges3;
            cmb_tables.DisabledState.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            cmb_tables.DrawMode = DrawMode.OwnerDrawFixed;
            cmb_tables.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_tables.FillColor = Color.FromArgb(175, 53, 102);
            cmb_tables.FocusedColor = Color.FromArgb(94, 148, 255);
            cmb_tables.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmb_tables.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_tables.ForeColor = Color.White;
            cmb_tables.ItemHeight = 30;
            cmb_tables.Location = new Point(738, 3);
            cmb_tables.Name = "cmb_tables";
            cmb_tables.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmb_tables.Size = new Size(267, 36);
            cmb_tables.TabIndex = 0;
            cmb_tables.SelectedIndexChanged += cmb_tables_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(426, 9);
            label1.Name = "label1";
            label1.Size = new Size(313, 23);
            label1.TabIndex = 3;
            label1.Text = "Список обладнання в таблиці - ";
            // 
            // inventory_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl_inventory_page);
            Name = "inventory_page";
            Size = new Size(1008, 546);
            Load += inventory_page_Load;
            pnl_inventory_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_inventory).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnl_inventory_page;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_tables;
        private Guna.UI2.WinForms.Guna2TextBox txt_search;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_inventory;
        private Label label1;
    }
}
