using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace svr_client_chat
{
    internal class handleClient
    {
        TcpClient clientSocket = null;
        public Dictionary<TcpClient, string> clientList = null; 

        public void startClient(TcpClient cliSocket, Dictionary<TcpClient, string> cliList)
        {
            this.clientSocket = cliSocket;
            this.clientList = cliList;

            Thread t_handler = new Thread(doChat);
            t_handler.IsBackground = true;
            t_handler.Start();
        }
        public delegate void MessageDisplayHandler(string message, string client_name);
        public event MessageDisplayHandler OnReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;
        private void doChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[]  buffer = new byte[1024];
                string  msg = string.Empty;
                int     size = 0;
                int     msgCnt = 0;

                while (true)
                {
                    // 메세지 갯수
                    msgCnt++;
                    //클라이언트소켓에서 가져올 것
                    stream = clientSocket.GetStream();
                    // 일단 1024만큼 읽어서 버퍼에 저장해와
                    size = stream.Read(buffer, 0, buffer.Length);
                    // 메세지를 unicode로 string 가져와
                    msg = Encoding.Unicode.GetString(buffer, 0, size);
                    msg = msg.Substring(0, msg.IndexOf("$"));

                    if (OnReceived != null)
                        OnReceived(msg, clientList[clientSocket].ToString());
                }
            }
            catch (SocketException se)
            {
                Trace.WriteLine(string.Format("dochat - SocketException : {0}", se.Message));

                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);
                    clientSocket.Close();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(string.Format("dochat - Exception : {0}", e.Message));

                if(clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);
                    clientSocket.Close();
                    stream.Close();

                }
            }
        }
    }
}
