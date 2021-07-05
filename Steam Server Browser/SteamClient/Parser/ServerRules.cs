using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
namespace Steam_Server_Browser.SteamClient.Parser
{
    public class ServerRules
    {
        public struct Commands
        {
            public string command;
            public string value;
        }
        public List<Commands> GetServerRules(IPEndPoint endPoint)
        {
            List<Commands> commands = new List<Commands>();
            SteamClient.Client client = new SteamClient.Client();

            var Message = client.GetServerRules(endPoint, 5000);
            if (Message.ShouldReturn)
            {
                byte[] recivedmsg = Message.data;
                var parser = new ResponseParser(recivedmsg);

                while (parser.CurrentPosition != recivedmsg.Length)
                {
                    commands.Add(new Commands
                    {
                        command = parser.GetStringToTermination(),
                        value = parser.GetStringToTermination()
                    });
                }
                return commands;
            }
            else
            {
                commands.Add(new Commands
                {
                    command = "n/a",
                    value = "n/a"
                });
                return commands;
            }
        }
    }
}
