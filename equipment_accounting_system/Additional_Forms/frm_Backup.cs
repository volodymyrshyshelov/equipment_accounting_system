using equipment_accounting_system.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace equipment_accounting_system.Additional_Forms
{
    public partial class frm_Backup : Form
    {
        private readonly db_Helper dbHelper;
        public frm_Backup()
        {
            InitializeComponent();
            dbHelper = new db_Helper();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (rb_backup.Checked)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "SQL files (*.sql)|*.sql";
                    saveFileDialog.Title = "Сохранить резервную копию";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        
                    }
                }
            }
            else if (rb_restore.Checked)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "SQL files (*.sql)|*.sql";
                    openFileDialog.Title = "Восстановить резервную копию";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        
                    }
                }

            }

       
        }
    }
}
