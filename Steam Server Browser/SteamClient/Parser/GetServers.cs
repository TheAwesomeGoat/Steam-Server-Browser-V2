using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

using System.Net;

using Steam_Server_Browser.SteamClient.Builder;
namespace Steam_Server_Browser.SteamClient.Parser
{
    public class GetServers
    {
        IPEndPoint Hl2_MasterServerEndPoint = new IPEndPoint(Dns.GetHostAddresses("hl2master.steampowered.com")[0], 27011);
        public List<IPEndPoint> GetSteamServers(int MaxBatches, IpFilter filter)
        {
            SteamClient.Client client = new Client();
            SteamClient.Parser.ServerIP ipParser = new ServerIP();

            IPEndPoint endPoint = Hl2_MasterServerEndPoint;

            List<IPEndPoint> ReturnEndPoints = new List<IPEndPoint>();

            int Batch = 1;
            while (true)
            {
                byte[] Message = client.GetServers(endPoint, 5000, filter);
                var Endpoints = ipParser.Parse(Message);

                foreach (var item in Endpoints)
                    ReturnEndPoints.Add(item);

                if (Batch == MaxBatches)
                    break;

                endPoint = Endpoints.Last();
                Batch++;
            }
            return ReturnEndPoints;
        }
    }
}
