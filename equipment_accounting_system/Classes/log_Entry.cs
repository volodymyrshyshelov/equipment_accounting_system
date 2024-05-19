using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class log_Entry
    {
        public int Id { get; set; }
        public DateTime LogTimestamp { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public string TableName { get; set; }
        public string LogType { get; set; }
        public string LogMessage { get; set; }
        public string Details { get; set; }

        public log_Entry() { }

        public log_Entry(int userId, string tableName, string logType, string logMessage, string details)
        {
            UserId = userId;
            TableName = tableName;
            LogType = logType;
            LogMessage = logMessage;
            Details = details;
        }
    }
}
