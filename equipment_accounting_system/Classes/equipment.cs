using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class equipment
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public byte[] EqImage { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public DateTime? LastRoutineMaintenanceDate { get; set; }
        public DateTime? NextRoutineMaintenanceDate { get; set; }
        public string WorkerUsername { get; set; } 
    }
}
