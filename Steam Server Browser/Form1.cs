using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Steam_Server_Browser.SteamClient.Parser;
using Steam_Server_Browser.SteamClient.Builder;

namespace Steam_Server_Browser
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IpFilter filter = new IpFilter()
            {
                AppId = "4000",
                Region = PacketBuilder.EnumRegions.All,
                HostName = "*Genesis*"
            };
            var ServerEndpoints = new GetServers().GetSteamServers(1, filter);
            List<ServerInfoClass> servers = new List<ServerInfoClass>();

            foreach (var item in ServerEndpoints)
            {
                try
                {
                    servers.Add(new ServerInfo().GetServerName(item));
                }
                catch
                {

                }
            }
        }
    }
}
