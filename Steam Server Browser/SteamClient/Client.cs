using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

using Steam_Server_Browser.SteamClient.Builder;

namespace Steam_Server_Browser.SteamClient
{
    public class Data
    {
        public byte[] data;
        public bool ShouldReturn;
    }
    public class Client
    {
        UdpClient client;
        public Data GetPlayers(IPEndPoint endPoint, int Timout)
        {
            try
            {
                client = new UdpClient(endPoint.Port);
                client.Client.ReceiveTimeout = Timout;
                client.Connect(endPoint);

                string Recieved = Encoding.Default.GetString(SendMessage($"ÿÿÿÿUÿÿÿÿ", endPoint).data);
                Data Message = SendMessage($"ÿÿÿÿU{Recieved.Split('A')[1]}", endPoint);

                CloseAndDispose();
                return Message;
            }
            catch
            {
                return new Data()
                {
                    data = new byte[0],
                    ShouldReturn = false
                };
            }
        }

        public Data GetServers(IPEndPoint endPoint, int Timout, IpFilter filter)
        {
            try
            {
                client = new UdpClient(endPoint.Port);
                client.Client.ReceiveTimeout = Timout;
                client.Connect(endPoint);

                Data Message = SendMessage(new PacketBuilder().BuildPacket(endPoint, filter), endPoint);

                CloseAndDispose();
                return Message;
            }
            catch
            {
                return new Data()
                {
                    data = new byte[0],
                    ShouldReturn = false
                };
            }
        }

        public Data GetServerInfo(IPEndPoint endPoint, int Timout)
        {
            try
            {
                client = new UdpClient(endPoint.Port);
                client.Client.ReceiveTimeout = Timout;
                client.Connect(endPoint);

                Data Message = SendMessage($"ÿÿÿÿTSource Engine Query\0", endPoint);

                CloseAndDispose();
                return Message;
            }
            catch
            {
                return new Data()
                {
                    data = new byte[0],
                    ShouldReturn = false
                };
            }
        }

        public Data GetServerRules(IPEndPoint endPoint, int Timout)
        {
            try
            {
                client = new UdpClient(endPoint.Port);
                client.Client.ReceiveTimeout = Timout;
                client.Connect(endPoint);

                Data Message = SendMessage($"ÿÿÿÿVÿÿÿÿ", endPoint);
                int header = BitConverter.ToInt32(new byte[] { Message.data[0], Message.data[1], Message.data[2], Message.data[3] }, 0);
                string S_Message = Encoding.Default.GetString(Message.data);

                if (header == -1)
                    Message = SendMessage($"ÿÿÿÿV{S_Message.Split('A')[1]}", endPoint);

                byte[] second = new byte[0];
                List<byte[]> bytes = new List<byte[]>();
                while (true)
                {
                    try
                    {
                        bytes.Add(client.Receive(ref endPoint));
                    }
                    catch
                    {
                        break;
                    }
                }

                for (int i = 0; i < bytes.Count; i++)
                    second = Combine(bytes[(bytes.Count - 1) - i].Skip(19 - (i == (bytes.Count - 1) ? 0 : 7)).ToArray(), second);


                CloseAndDispose();
                return Message;
            }
            catch
            {
                return new Data()
                {
                    data = new byte[0],
                    ShouldReturn = false
                };
            }
        }

        private byte[] Combine(byte[] first, byte[] second)
        {
            byte[] bytes = new byte[(first.Length) + second.Length];
            Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
            Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }
           
        private void CloseAndDispose()
        {
            client.Close();
            client.Dispose();
        }

        private Data SendMessage(string msg, IPEndPoint endPoint)
        {
            try
            {
                client.Send(Encoding.Default.GetBytes(msg), msg.Length);
                return new Data
                {
                    data = client.Receive(ref endPoint),
                    ShouldReturn = true
                };
                    
            }
            catch (System.Net.Sockets.SocketException)
            {
                return new Data
                {
                    data = new byte[0],
                    ShouldReturn = false
                };
            }
        }
    }
}
