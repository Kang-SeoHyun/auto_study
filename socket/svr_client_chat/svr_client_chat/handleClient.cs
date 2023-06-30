using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace svr_client_chat
{
    internal class HandleClient
    {
        private TcpClient clientSocket = null;
        private Dictionary<TcpClient, string> clientMap;
        private Dictionary<TcpClient, HandleClient> clientList;
        private Dictionary<string, List<TcpClient>> chatRooms;
        private string roomName = string.Empty;

        public HandleClient(TcpClient clientSocket, Dictionary<TcpClient, string> clientMap, Dictionary<TcpClient, HandleClient> clientList, Dictionary<string, List<TcpClient>> chatRooms)
        {
            this.clientSocket = clientSocket;
            this.clientMap = clientMap;
            this.clientList = clientList;
            this.chatRooms = chatRooms;
        }

        public void startClient(string room)
        {
            this.roomName = room;
            Thread t_handler = new Thread(DoChat);
            // t_handler 스레드객체를 백그라운드 스레드로 설정하는 역할
            // 애플리케이션이 종료될 때 스레드도 종료되게 함!
            t_handler.IsBackground = true;
            t_handler.Start();
            if (!chatRooms.ContainsKey(room))
            {
                chatRooms[room] = new List<TcpClient>();
            }
            chatRooms[room].Add(clientSocket);
        }

        public delegate void MessageDisplayHandler(string msg, string client_name, string roomName);
        public event MessageDisplayHandler OnReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;

        // Dochat 메서드를 실행하는 건 t_handler 스레드
        private void DoChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[] buffer = new byte[1024];
                string msg = string.Empty;
                int size = 0;
                int msgCnt = 0;

                while (true)
                {
                    msgCnt++;
                    //클라이언트소켓에서 가져올 것
                    stream = clientSocket.GetStream();
                    // 일단 1024만큼 읽어서 버퍼에 저장해와
                    size = stream.Read(buffer, 0, buffer.Length);
                    // 메세지를 unicode로 string 가져와
                    msg = Encoding.Unicode.GetString(buffer, 0, size);
                    msg = msg.Substring(0, msg.IndexOf("$"));

                    OnReceived?.Invoke(msg, clientMap[clientSocket], roomName);
                }
            }
            catch (SocketException se)
            {
                // 추적기능을 제공.
                Trace.WriteLine($"Error : Dochat : SocketException : {se.Message}");

                if (clientSocket != null)
                {
                    OnDisconnected?.Invoke(clientSocket);
                    clientSocket.Close();
                    // stream 있으면 닫기
                    stream?.Close();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error: DoChat: Exception: {ex.Message}");

                if (clientSocket != null)
                {
                    OnDisconnected?.Invoke(clientSocket);
                    clientSocket.Close();
                    stream?.Close();
                }
            }
        }

        public void StopClient()
        {
            try
            {
                if (clientSocket.Connected)
                {
                    // 연결 닫고, 리소스 해제
                    clientSocket.GetStream().Close();
                    clientSocket.Close();
                    // 이벤트 핸들러 등록 해제 및 객체 정리
                    OnReceived = null;
                    OnDisconnected = null;
                    clientList = null;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"StopClient - Exception: {ex.Message}");
            }
        }
    }
}