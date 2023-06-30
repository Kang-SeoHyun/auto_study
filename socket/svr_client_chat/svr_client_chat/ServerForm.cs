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
    public partial class ServerForm : Form
    {
        // 소켓 생성
        private TcpListener server;
        private TcpClient client;
        private Dictionary<TcpClient, string> clientMap = new Dictionary<TcpClient, string>();
        private Dictionary<TcpClient, HandleClient> clientList = new Dictionary<TcpClient, HandleClient>();
        // 채팅방 이름이랑 회원 정보 갖고있는
        private Dictionary<string, List<TcpClient>> chatRooms = new Dictionary<string, List<TcpClient>>();

        public ServerForm()
        {
            InitializeComponent();
            //socket start
            Thread socketThread = new Thread(InitSocket);
            socketThread.IsBackground = true;
            socketThread.Start();

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
                    // 서버가 클라이언트 연결요청을 수락함
                    client = server.AcceptTcpClient();
                    DisplayText("Accept connection from client");

                    NetworkStream stream = client.GetStream();
                    
                    byte[] buffer = new byte[1024];
                    int size = stream.Read(buffer, 0, buffer.Length);
                    string usrName = Encoding.Unicode.GetString(buffer, 0, size);
                    usrName = usrName.Substring(0, usrName.IndexOf("$"));
                    clientMap.Add(client, usrName);

                    buffer = new byte[1024];
                    size = stream.Read(buffer, 0, buffer.Length);
                    string roomName = Encoding.Unicode.GetString(buffer, 0, size);
                    roomName = roomName.Substring(0, roomName.IndexOf("$"));
                    if (chatRooms.ContainsKey(roomName))
                    {
                        // 채팅방 존재하면 클라이언트 추가하기
                        List<TcpClient> clients = chatRooms[roomName];
                        clients.Add(client);
                    }
                    else
                    {
                        List<TcpClient> clients = new List<TcpClient> {client};
                        chatRooms.Add(roomName, clients);
                    }

                    HandleClient hClient = new HandleClient(client, clientMap, clientList, chatRooms);
                    hClient.OnReceived += OnReceived;
                    hClient.OnDisconnected += HClient_OnDisconnected;
                    hClient.startClient(roomName);

                    clientList.Add(client, hClient);
                    // 모든 유저한테 메세지 보내기
                    SendMsgAll($"{clientMap[client]}님이 들어왔어요.", "Server", false, chatRooms[roomName]);

                }
                catch (SocketException se)
                {
                    Trace.WriteLine($"InitSocket - SocketException: {se.Message}");
                    break;
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"InitSocket - Exception: {e.Message}");
                    break;
                }
            }
            client.Close();
            server.Stop();
        }

        private void OnReceived(string msg, string client_name, string roomName)
        {
            List < TcpClient > clients = chatRooms[roomName];
            string displayMsg = $"In {roomName}: From {client_name}: {msg}";
            DisplayText(displayMsg);
            SendMsgAll(msg, client_name, true, clients);
        }

        void HClient_OnDisconnected(TcpClient client)
        {
            if (clientList.ContainsKey(client))
            {
                HandleClient hClient = clientList[client];
                hClient.OnReceived -= OnReceived;
                hClient.OnDisconnected -= HClient_OnDisconnected;
                hClient.StopClient();

                clientList.Remove(client);
            }
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
            foreach (var member in clientMap)
            {
                TcpClient client = member.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;
                // 클라이언트가 말할 때
                if (flag)
                {
                    buffer = Encoding.Unicode.GetBytes($"{client_name}: {msg}");
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
        public void SendMsgAll(string msg, string client_name, bool flag, List<TcpClient> clients)
        {
            foreach (var client in clients)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;
                // 클라이언트가 말할 때
                if (flag)
                {
                    buffer = Encoding.Unicode.GetBytes($"{client_name}: {msg}");
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

            foreach (var member in clientList)
            {
                TcpClient client = member.Key;
                HandleClient hClient = member.Value;

                hClient.OnReceived -= OnReceived;
                hClient.OnDisconnected -= HClient_OnDisconnected;
                hClient.StopClient();

                client.Close();
            }
            server.Stop();
        }
    }
}