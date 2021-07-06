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

            int appid = (int)Enum.Parse(typeof(PacketBuilder.SourceEngineGames), GameName);
            
            IpFilter filter = new IpFilter()
            {
                AppId = appid.ToString(),
                Region = new Utils.PickRegion().Pick(Region),
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
            DataGridServers.Rows.Clear();
            int Index = 0;
            if (ServerEndpoints[0].Address.ToString() != "0.0.0.0")
            {
                foreach (var Endpoint in ServerEndpoints)
                {
                    try
                    {
                        ServerInfoClass info = new ServerInfo().GetServerName(Endpoint);
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
            else
            {
                invokers.AddDataItem(new string[]
                {
                    "n/a",
                    "No Servers Found",
                    "n/a",
                    "n/a",
                    "n/a",
                    "n/a"
                }, DataGridServers);
            }
        }

        private void StopSearch_Click(object sender, EventArgs e)
        {
            if (SearchServersThread != null)
                if (!SearchServersThread.IsAlive)
                    SearchServersThread.Abort();
            new SteamClient.Client().CloseAndDispose();
        }

        // 0, Index 
        // 1, Server Name 
        // 2, Players 
        // 3, Bots
        // 4, Server IP
        // 5, Port
        private void DataGridServers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;

            if (RIndex > 0)
                ServerIPTextBox.Text = DataGridServers.Rows[RIndex].Cells[4].Value.ToString();
        }

        private void DataGridServers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            DataGrid_Players.Rows.Clear();
            if (RIndex > 0)
            {
                string ServerIP = DataGridServers.Rows[RIndex].Cells[4].Value.ToString();
                string port = DataGridServers.Rows[RIndex].Cells[5].Value.ToString();

                List<ServerPlayers.PlayerInfo> Players = new ServerPlayers().GetPlayers(new IPEndPoint(IPAddress.Parse(ServerIP), int.Parse(port)));

                new Thread(() =>
                {
                    if (Players != null)
                    {
                        foreach (var player in Players)
                        {
                            int Hour = 0;
                            int Minutes = 0;
                            int Seconds = 0;

                            try
                            {
                                var Time = TimeSpan.FromSeconds(float.IsNaN(player.Duration) ? 0.0f : player.Duration);
                                Hour = Time.Hours;
                                Minutes = Time.Minutes;
                                Seconds = Time.Seconds;
                            }
                            catch { }

                            invokers.AddDataItem(new string[]
                            {
                                player.Name,
                                player.Score.ToString(),
                                $"{(Hour == 0 ? $"" : $"{Hour}h " )}{((Minutes == 0 & Hour == 0) ? $"" : $"{Minutes}m " )}{((Seconds == 0 & Minutes == 0 & Hour == 0) ? $"" : $"{Seconds}s " )}"
                            }, DataGrid_Players);
                        }
                    }
                    else
                    {
                        invokers.AddDataItem(new string[]
                        {
                            "No Players Found",
                            "n/a",
                            "n/a"
                        }, DataGrid_Players);
                    }
                }).Start();
            }
        }
    }
}
