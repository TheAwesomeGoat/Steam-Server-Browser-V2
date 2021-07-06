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

        private void GetRulesButton_Click(object sender, EventArgs e)
        {
            string IP = RuleIP.Text.Split(':')[0];
            string Port = RuleIP.Text.Split(':')[1];
            new Thread(() =>
            {
                List<ServerRules.Commands> Rules = new ServerRules().GetServerRules(new IPEndPoint(IPAddress.Parse(IP), int.Parse(Port)));
                foreach (var Rule in Rules)
                {
                    invokers.AddDataItem(new string[]
                    {
                        Rule.command,
                        Rule.value
                    }, DataGridRules);
                }

            }).Start();
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
        GetCellValue DtCell = new GetCellValue();
        private void DataGridServers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;

            if (RIndex >= 0)
            {
                ServerIPTextBox.Text = DtCell.GetCell(DataGridServers, RIndex, 4);
                RuleIP.Text = $"{DtCell.GetCell(DataGridServers, RIndex, 4)}:{DtCell.GetCell(DataGridServers, RIndex, 5)}";
            }
        }

        private void DataGridServers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            DataGrid_Players.Rows.Clear();
            if (RIndex >= 0)
            {
                string ServerIP = DtCell.GetCell(DataGridServers, RIndex, 4);
                string port = DtCell.GetCell(DataGridServers, RIndex, 5);

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

        SteamClient.Rcon rcon = new SteamClient.Rcon();
        private void RconConnect_Click(object sender, EventArgs e)
        {
            string IP = RconIP_TB.Text;
            string Port = RconPort_TB.Text;
            string Pass = RconPassword_TB.Text;
            bool handshake = rcon.Connect(new IPEndPoint(IPAddress.Parse(IP), int.Parse(Port)), Pass);
            if (handshake)
            {
                Rcon_GB.Enabled = true;
            }
        }

        private void RconDisconnect_Click(object sender, EventArgs e)
        {
            rcon.Disconnect();
            Rcon_GB.Enabled = false;
        }

        private void SendRconCommand_Click(object sender, EventArgs e)
        {
            SendCommand(RconCommandTB.Text);
        }
        public void SendCommand(string Command)
        {
            if (!string.IsNullOrEmpty(Command))
            {
                new Thread(() =>
                {
                    var rcnOut = rcon.SendCommand(Command);

                    if (rcnOut.valid)
                        invokers.TextboxAddText(RconLog_TB, rcnOut.Out == "" ? $"Sent: {Command}" : rcnOut.Out);
                    else
                        invokers.TextboxAddText(RconLog_TB, "Send Failed");

                }).Start();
            }
        }
    }
}
