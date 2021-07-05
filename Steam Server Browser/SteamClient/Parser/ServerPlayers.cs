﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
namespace Steam_Server_Browser.SteamClient.Parser
{
    public class ServerPlayers
    {
        public struct PlayerInfo
        {
            public int Index;
            public string Name;
            public int Score;
            public float Duration;
            public bool valid;
        }

        public List<PlayerInfo> GetPlayers(IPEndPoint endPoint)
        {
            List<PlayerInfo> players = new List<PlayerInfo>();
            SteamClient.Client client = new SteamClient.Client();
            try
            {
                byte[] recivedmsg = client.GetPlayers(endPoint, 5000);

                var parser = new ResponseParser(recivedmsg);
                parser.CurrentPosition += 5;
                byte playersCount = parser.GetByte();
                try
                {
                    for (int i = 0; i < recivedmsg.Count(); i += 4)
                    {
                        players.Add(new PlayerInfo
                        {
                            Index = parser.GetByte(),
                            Name = parser.GetStringToTermination(),
                            Score = (int)parser.GetLong(),
                            Duration = parser.GetFloat(),
                            valid = true
                        });
                    }
                }
                catch (Exception e) { var a = e; }

                if (players.Count != 0)
                    return players;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
