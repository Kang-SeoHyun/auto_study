using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_test
{
    public partial class Server : Form
    {
       // TCP 소켓을 사용하여 클라이언트와 서버 간의 통신을 수행함.
       TcpListener server;
        
        TcpClient client;

        StreamReader Reader;
        StreamWriter Writer;
        NetworkStream stream;

        Thread ReceiveThread;

        bool Connected;

        private delegate void AddTextDelegate(string strText);

        public Server()
        {
            InitializeComponent();
        }
        private void Listen()
        {
            // 1.채팅방에 텍스트 추가 -> delegate 함수
            AddTextDelegate AddText = new AddTextDelegate(txt_server_chat.AppendText);

            // 2.서버 세팅
            IPAddress addr = IPAddress.Parse("127.0.0.1"); // Server Socket에 bind할 IP주소, 필자는 루프백 주소인 127.0.0.1 사용함
            int port = 8080;
            server = new TcpListener(addr, port);
            server.Start();

            Invoke(AddText, "Server Start" + "\r\n");

            // 3.클라이언트 세팅
            client = server.AcceptTcpClient();
            Connected = true;

            Invoke(AddText, "Connected to Client" + "\r\n");

            // 4. stream 생성
            stream = client.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);

            // 5. receive 쓰레드 start
            ReceiveThread = new Thread(new ThreadStart(Receive));
            ReceiveThread.Start();
        }

        // 클라이언트한테 메세지오면 채팅화면에 출력해주기위해 실행시키는 메서드
        // stream 계속 모니터링하다가 canread(클이 보내서 stream에 메세지들오면)되면 리더가 읽어서 채팅화면에 출력
        // 서버에서 클라이언트로 메세지 보내고 싶으면 버튼 누르면 됨.
        private void Receive()
        {
            AddTextDelegate AddText = new AddTextDelegate(txt_server_chat.AppendText);

            while (Connected)
            {
                // stream에 data 있을 경우 
                if (stream.CanRead)
                {
                    // 클라이언트꺼지고 채팅 값있는거 보내면 여기서 에러뜸 그냥 예외처리해주면 될 듯
                    string receiveChat = Reader.ReadLine();
                    // 둘 중 하나꺼지고 채팅 값있는거 보내먄 Invoke에서 에러뜸 그냥 예외처리해주면 될 듯
                    if (receiveChat != null && receiveChat.Length > 0)
                        Invoke(AddText, "You: " + receiveChat + "\r\n");
                }
            }
        }
        private void Server_Load(object sender, EventArgs e)
        {
            Thread ListenThread = new Thread(new ThreadStart(Listen));
            ListenThread.Start();
        }

        // 버튼 눌러서 채팅 보내는 과정
        private void button_server_send_Click(object sender, EventArgs e)
        {
            // 채팅방에 메세지 추가
            txt_server_chat.AppendText("Me: " + txt_server_send.Text + "\r\n");

            // 클라이언트에 채팅보냄
            Writer.WriteLine(txt_server_send.Text);
            Writer.Flush();

            txt_server_send.Clear();
        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;
            if (Reader != null) Reader.Close();
            if (Writer != null) Writer.Close();
            if (server != null) server.Stop();
            if (client != null) client.Close();
            if (ReceiveThread != null) ReceiveThread.Abort();
        }
    }
}
