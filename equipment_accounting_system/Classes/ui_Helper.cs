using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class ui_Helper
    {
        public void addControl( UserControl userControl, Panel panelContainer) { 
        
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        
        }
    }
}
