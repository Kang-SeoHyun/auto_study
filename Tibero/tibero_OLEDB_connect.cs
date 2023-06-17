using System.Data.OleDb;


string sql = "Provider=tbprov.Tbprov.6; Data Source =192.168.0.1, 7000, DBTest; User ID = admin; Password=admin99;"
               + "Persist Security Info = True";              //      서버IP, PORT, DB Name;    ID;          PWD;  작성해주면 됩니다. 

            conn = new OleDbConnection(sql);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from 테이블");
            cmd.Connection = conn; // Connection 초기화 하지 않으면 속성이 초기화되지 않았다는 에러메세지가 뜬다.
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                string txtData = read.GetValue(1).ToString();
            }

            read.Close();
            conn.Close();