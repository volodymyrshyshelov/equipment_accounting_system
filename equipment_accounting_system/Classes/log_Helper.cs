using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class log_Helper
    {
        private readonly string connectionString;

        public log_Helper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertLogEntry(log_Entry logEntry)
        {
            string query = @"
            INSERT INTO logs (log_timestamp, user_id, table_name, log_type, log_message, details) 
            VALUES (@LogTimestamp, @UserId, @TableName, @LogType, @LogMessage, @Details)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LogTimestamp", logEntry.LogTimestamp);
                    cmd.Parameters.AddWithValue("@UserId", logEntry.UserId);
                    cmd.Parameters.AddWithValue("@TableName", logEntry.TableName);
                    cmd.Parameters.AddWithValue("@LogType", logEntry.LogType);
                    cmd.Parameters.AddWithValue("@LogMessage", logEntry.LogMessage);
                    cmd.Parameters.AddWithValue("@Details", logEntry.Details);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
