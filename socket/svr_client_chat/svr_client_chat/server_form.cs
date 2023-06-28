using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svr_client_chat
{
    public partial class server_form : Form
    {
        // 소켓 생성
        TcpListener server = null;
        TcpClient client = null;
        static int counter = 0;

        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();
        public server_form()
        {
            InitializeComponent();

            //socket start
            Thread t = new Thread(InitSocket);
            t.IsBackground = true;
            t.Start();
        }
        private void InitSocket()
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            // 서버를 연결요청이 가능한 상태로 만듬 - bind와 listen 함수호출과 같은 기능
            server = new TcpListener(iPAddress, 9862);
            client = default(TcpClient);
            server.Start();
            DisplayText("!!!!!!!! Server started !!!!!!!!");

            while (true)
            {
                try
                {
                    counter++;
                    // 서버가 클라이언트 연결요청을 수락함
                    client = server.AcceptTcpClient();
                    DisplayText("Accept connection from client");

                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int size = stream.Read(buffer, 0, buffer.Length);
                    string client_name = Encoding.Unicode.GetString(buffer, 0, size);
                    client_name = client_name.Substring(0, client_name.IndexOf("$"));

                    clientList.Add(client, client_name);

                    // 모든 유저한테 메세지 보내기
                    SendMsgAll(client_name + " 님이 들어왔어요.", "Server", false);

                    handleClient h_client = new handleClient();
                    h_client.OnReceived += new handleClient.MessageDisplayHandler(OnReceived);
                    h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected);
                    h_client.startClient(client, clientList);
                }
                catch (SocketException se)
                {
                    Trace.WriteLine(string.Format("InitSocket - SocketException : {0}", se.Message));
                    break;
                }
                catch (Exception e) 
                {
                    Trace.WriteLine(string.Format("InitSocket - Exception : {0}", e.Message));
                    break;
                }
            }
            client.Close();
            server.Stop();
        }
        
        private void OnReceived(string msg, string client_name)
        {
            string displayMsg = "From " + client_name + " : " + msg;
            DisplayText(displayMsg);
            SendMsgAll(msg, client_name, true);
        }

        void h_client_OnDisconnected(TcpClient client)
        {
            if (clientList.ContainsKey(client))
                clientList.Remove(client);
        }
        private void DisplayText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new MethodInvoker(delegate { richTextBox1.AppendText(text + Environment.NewLine); }));
            }
            else
                richTextBox1.AppendText(text + Environment.NewLine);
        }

        public void SendMsgAll(string msg, string client_name, bool flag)
        {
            foreach(var member in clientList)
            {
                Trace.WriteLine(string.Format("tcpclient : {0} name : {1}", member.Key, member.Value));
                TcpClient client = member.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;
                // 클라이언트가 말할 때
                if (flag)
                {
                    buffer = Encoding.Unicode.GetBytes(client_name + " : " + msg);
                }
                // 서버가 말할 때
                else
                {
                    buffer = Encoding.Unicode.GetBytes(msg);
                }
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        private void server_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendMsgAll("서버가 종료되었습니다.", "Server", false);

            foreach (var member in clientList.Keys)
            {
                member.Close();
            }
            server.Stop();
        }
    }
}
