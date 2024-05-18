namespace equipment_accounting_system.Controls
{
    partial class report_page
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnl_report_page = new Guna.UI2.WinForms.Guna2GradientPanel();
            SuspendLayout();
            // 
            // pnl_report_page
            // 
            pnl_report_page.CustomizableEdges = customizableEdges1;
            pnl_report_page.Dock = DockStyle.Fill;
            pnl_report_page.FillColor = Color.FromArgb(183, 54, 101);
            pnl_report_page.FillColor2 = Color.FromArgb(29, 38, 113);
            pnl_report_page.Location = new Point(0, 0);
            pnl_report_page.Name = "pnl_report_page";
            pnl_report_page.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnl_report_page.Size = new Size(1008, 546);
            pnl_report_page.TabIndex = 1;
            // 
            // report_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl_report_page);
            Name = "report_page";
            Size = new Size(1008, 546);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnl_report_page;
    }
}
