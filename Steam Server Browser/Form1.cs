using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;

using Steam_Server_Browser.SteamClient.Parser;
using Steam_Server_Browser.SteamClient.Builder;
using Steam_Server_Browser.Utils;

using System.Net;

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
            RegionComboBox.Text = "All";
            GameComboBox.Text = "Garrys_Mod";
        }

        Thread SearchServersThread;
        List<IPEndPoint> ServerEndpoints;

        Invokers invokers = new Invokers();
        private void GetServersButton_Click(object sender, EventArgs e)
        {
            string GameName = GameComboBox.SelectedItem.ToString();
            string Region = RegionComboBox.SelectedItem.ToString();

            IpFilter filter = new IpFilter()
            {
                AppId = "4000",
                Region = PacketBuilder.EnumRegions.All,
                HostName = HostnameTextBox.Text,
                Map = MapTextBox.Text,
                IsNotEmpty = NotEmpty_CB.Checked
            };
            ServerEndpoints = new GetServers().GetSteamServers(1, filter);

            SearchServersThread = new Thread(SearchServers);
            SearchServersThread.Start();
        }
        public void SearchServers()
        {
            int Index = 0;
            foreach (var item in ServerEndpoints)
            {
                try
                {
                    ServerInfoClass info = new ServerInfo().GetServerName(item);
                    if (info.ServerName != "n/a")
                    {
                        invokers.AddDataItem(new string[]
                        {
                            Index++.ToString("00000.#####"),
                            info.ServerName,
                            $"{info.Players}/{info.MaxPlayers}",
                            info.Bots.ToString(),
                            info.ServerIP,
                            info.Port.ToString()

                        }, DataGridServers);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
