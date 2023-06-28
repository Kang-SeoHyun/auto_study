using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_test_cli
{
    public partial class Client : Form
    {
        // tcp 클라이언트 객체
        // 이 객체를 이용하여 서버에 연결
        TcpClient client;

        // 데이터를 읽기 위한 스트림 리더
        StreamReader reader;
        // 데이터를 쓰기 위한 스트림 라이터
        StreamWriter writer;
        // 네트워크 스트림
        NetworkStream stream;

        // 수신 스레드
        Thread ReceiveThread;

        // 연결상태를 나타내는 플래그
        bool Connected;

        // 텍스트를 추가하기 위한 델리게이트
        private delegate void AddTextDelegate(string strText);
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // 연결할 대상(Server)의 IP 주소랑 포트 번호 일단 루프백 이용
            string IP = "127.0.0.1";
            int port = 8080;

            client = new TcpClient();
            // 서버에 연결
            client.Connect(IP, port);

            stream = client.GetStream();
            Connected = true;

            txt_client_chat.AppendText("Connected to Server" + "\r\n");
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            // 수신 스레드 생성
            ReceiveThread = new Thread(new ThreadStart(Receive));
            // 수신 스레드 시작
            ReceiveThread.Start();
        }

        private void button_client_send_Click(object sender, EventArgs e)
        {
            txt_client_chat.AppendText("Me: " + txt_client_send.Text + "\r\n");
            // 서버로 메시지 전송
            writer.WriteLine(txt_client_send.Text);
            // 버퍼 비우기
            writer.Flush();
            txt_client_send.Clear();
        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;

            if (reader != null) reader.Close();
            if (writer != null) writer.Close();
            if (client != null) client.Close();
            if (ReceiveThread != null) ReceiveThread.Abort();
        }

        private void Receive()
        {
            // 수신 스레드에서 생성하며 서버로부터의 메시지를 수신함.
            AddTextDelegate AddText = new AddTextDelegate(txt_client_chat.AppendText);

            while (Connected)
            {
                if (stream.CanRead)
                {
                    // 둘 중 하나 꺼지고 데이터값없이보내면 ㄱㅊ은데 채팅치고 보내면 Invoke에서 에러뜸 그냥 예외처리해주면 될 듯
                    // 데이터를 읽고 채팅창에 표시
                    string ReceiveData = reader.ReadLine();
                    if (ReceiveData != null && ReceiveData.Length > 0)
                        Invoke(AddText, "You: " + ReceiveData + "\r\n");
                }
            }
        }
    }
}
