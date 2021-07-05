using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace Steam_Server_Browser.SteamClient.Parser
{
    public class ServerInfoClass
    {
        public int Protocol { get; set; }
        public string ServerName { get; set; }
        public string Map { get; set; }
        public string Folder { get; set; }
        public string Game { get; set; }
        public int ID { get; set; }
        public byte Players { get; set; }
        public byte MaxPlayers { get; set; }
        public byte Bots { get; set; }
        public string ServerType { get; set; }
        public string Environment { get; set; }
        public byte Visibility { get; set; }
        public string Version { get; set; }
        public string ServerIP { get; set; }
        public int Port { get; set; }
        public bool Valid { get; set; }
        public int TimoutTime { get; set; }
    }
    public class ServerInfo
    {
        public ServerInfoClass GetServerName(IPEndPoint endPoint)
        {
            SteamClient.Client client = new SteamClient.Client();

            var Message = client.GetServerInfo(endPoint, 500);
            if (Message.ShouldReturn)
            {
                var parser = new ResponseParser(Message.data);

                return new ServerInfoClass()
                {
                    Protocol = parser.GetByte(),
                    ServerName = parser.GetStringToTermination(),
                    Map = parser.GetStringToTermination(),
                    Folder = parser.GetStringToTermination(),
                    Game = parser.GetStringToTermination(),
                    ID = parser.GetShort(),
                    Players = parser.GetByte(),
                    MaxPlayers = parser.GetByte(),
                    Bots = parser.GetByte(),
                    ServerType = parser.GetStringOfByte(),
                    Environment = parser.GetStringOfByte(),
                    Visibility = parser.GetByte(),
                    Version = parser.GetStringToTermination(),
                    ServerIP = endPoint.Address.ToString()
                };
            }
            else
            {
                return new ServerInfoClass()
                {
                    Protocol = 0,
                    ServerName = "n/a",
                    Map = "n/a",
                    Folder = "n/a",
                    Game = "n/a",
                    ID = 0,
                    Players = 0,
                    MaxPlayers = 0,
                    Bots = 0,
                    ServerType = "n/a",
                    Environment = "n/a",
                    Visibility = 0,
                    Version = "n/a",
                    ServerIP = "n/a"
                };
            }
        }
    }
}
