using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class log_Operation
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string OperationType { get; set; }
        public string TableName { get; set; }
        public string Details { get; set; }
    }
}
