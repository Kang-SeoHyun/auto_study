using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibero.DbAccess;
using System.Data.OleDb;

namespace chatClient
{
    internal class DBConnect
    {
        private OleDbConnection conn;
        public DBConnect()
        {
            string DbInfo = "Provider=tbprov.Tbprov.6; Location=127.0.0.1, 8629; Data Source=tibero; User ID = sys; Password=6615;"
            + "Persist Security Info = True";

            conn = new OleDbConnection(DbInfo);
            conn.Open();
        }

        public string GetName(string UserId)
        {
            OleDbConnection conn = GetConnection();
            string sql = "SELECT UserName FROM MEMBERS WHERE UserId = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("?", UserId);
                string UserName = (string)checkCmd.ExecuteScalar();
                return UserName;
            }
        }
        public string GetTime()
        {
            OleDbConnection conn = GetConnection();

            string sql = "SELECT TO_CHAR(SYSDATE, 'HH24:MI') AS Time FROM DUAL";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                string time = (string)cmd.ExecuteScalar();
                return time;
            }
        }

        public OleDbConnection GetConnection()
        {
            return conn;
        }

        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
