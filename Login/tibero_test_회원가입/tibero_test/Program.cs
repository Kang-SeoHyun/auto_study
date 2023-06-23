using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tibero.DbAccess;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace tibero_test
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            // 데이터베이스 연결 문자열
            string DbInfo = "Provider=tbprov.Tbprov.6; Location=127.0.0.1, 8629; Data Source=tibero; User ID = sys; Password=6615;"
                + "Persist Security Info = True";
            
            // dbconnection 개체 생성하여 연결 문자열 사용하여 데이터베이스 연결
            OleDbConnectionTbr conn = new OleDbConnectionTbr(DbInfo);
            conn.Open();
            try
            {
                // 테이블 생성 SQL 문 작성
                string sql = "CREATE TABLE IF NOT EXISTS Users (" +
                        "ID NUMBER PRIMARY KEY," +
                        "UserName VARCHAR2(30) NOT NULL," +
                        "UserID VARCHAR2(30) NOT NULL," +
                        "Password VARCHAR2(30) NOT NULL," +
                        "Email VARCHAR2(255) NOT NULL" +
                        ")";
                OleDbCommandTbr cmd = new OleDbCommandTbr(sql, conn);
                cmd.ExecuteNonQuery();
                
                
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string txtData = reader.GetValue(1).ToString();
                    // 데이터 처리
                    // string columnValue = reader.GetString(0);
                    // Console.WriteLine(columnValue);
                }
                // 데베 작업 마친 후에 연결 닫아야함!
                reader.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally 
            {
                conn.Close(); 
            }
            */
            // 여기 위에가 데이터 베이스 연결, 테이블생성 부분 코드!
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new home());
            
            //if 로그인성공했으면
            Application.Run(new ChatList());
        }
    }
}
