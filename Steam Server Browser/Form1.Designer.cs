
namespace Steam_Server_Browser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ServerIPLabel = new System.Windows.Forms.Label();
            this.ServerIPTextBox = new System.Windows.Forms.TextBox();
            this.StopSearch = new System.Windows.Forms.Button();
            this.HostNameLabel = new System.Windows.Forms.Label();
            this.MapLabel = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.RegionLabel = new System.Windows.Forms.Label();
            this.GetServersButton = new System.Windows.Forms.Button();
            this.DataGrid_Players = new System.Windows.Forms.DataGridView();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridServers = new System.Windows.Forms.DataGridView();
            this.ServerIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotEmpty_CB = new System.Windows.Forms.CheckBox();
            this.HostnameTextBox = new System.Windows.Forms.TextBox();
            this.MapTextBox = new System.Windows.Forms.TextBox();
            this.GameComboBox = new System.Windows.Forms.ComboBox();
            this.RegionComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Players)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridServers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1347, 622);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ServerIPLabel);
            this.tabPage1.Controls.Add(this.ServerIPTextBox);
            this.tabPage1.Controls.Add(this.StopSearch);
            this.tabPage1.Controls.Add(this.HostNameLabel);
            this.tabPage1.Controls.Add(this.MapLabel);
            this.tabPage1.Controls.Add(this.GameLabel);
            this.tabPage1.Controls.Add(this.RegionLabel);
            this.tabPage1.Controls.Add(this.GetServersButton);
            this.tabPage1.Controls.Add(this.DataGrid_Players);
            this.tabPage1.Controls.Add(this.DataGridServers);
            this.tabPage1.Controls.Add(this.NotEmpty_CB);
            this.tabPage1.Controls.Add(this.HostnameTextBox);
            this.tabPage1.Controls.Add(this.MapTextBox);
            this.tabPage1.Controls.Add(this.GameComboBox);
            this.tabPage1.Controls.Add(this.RegionComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1339, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ServerIPLabel
            // 
            this.ServerIPLabel.AutoSize = true;
            this.ServerIPLabel.Location = new System.Drawing.Point(863, 573);
            this.ServerIPLabel.Name = "ServerIPLabel";
            this.ServerIPLabel.Size = new System.Drawing.Size(51, 13);
            this.ServerIPLabel.TabIndex = 9;
            this.ServerIPLabel.Text = "Server IP";
            // 
            // ServerIPTextBox
            // 
            this.ServerIPTextBox.Location = new System.Drawing.Point(920, 570);
            this.ServerIPTextBox.Name = "ServerIPTextBox";
            this.ServerIPTextBox.ReadOnly = true;
            this.ServerIPTextBox.Size = new System.Drawing.Size(413, 20);
            this.ServerIPTextBox.TabIndex = 8;
            // 
            // StopSearch
            // 
            this.StopSearch.Location = new System.Drawing.Point(101, 6);
            this.StopSearch.Name = "StopSearch";
            this.StopSearch.Size = new System.Drawing.Size(75, 23);
            this.StopSearch.TabIndex = 7;
            this.StopSearch.Text = "Stop";
            this.StopSearch.UseVisualStyleBackColor = true;
            this.StopSearch.Click += new System.EventHandler(this.StopSearch_Click);
            // 
            // HostNameLabel
            // 
            this.HostNameLabel.AutoSize = true;
            this.HostNameLabel.Location = new System.Drawing.Point(319, 65);
            this.HostNameLabel.Name = "HostNameLabel";
            this.HostNameLabel.Size = new System.Drawing.Size(55, 13);
            this.HostNameLabel.TabIndex = 6;
            this.HostNameLabel.Text = "Hostname";
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(319, 39);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(28, 13);
            this.MapLabel.TabIndex = 6;
            this.MapLabel.Text = "Map";
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.Location = new System.Drawing.Point(5, 64);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(35, 13);
            this.GameLabel.TabIndex = 6;
            this.GameLabel.Text = "Game";
            // 
            // RegionLabel
            // 
            this.RegionLabel.AutoSize = true;
            this.RegionLabel.Location = new System.Drawing.Point(5, 38);
            this.RegionLabel.Name = "RegionLabel";
            this.RegionLabel.Size = new System.Drawing.Size(41, 13);
            this.RegionLabel.TabIndex = 6;
            this.RegionLabel.Text = "Region";
            // 
            // GetServersButton
            // 
            this.GetServersButton.Location = new System.Drawing.Point(6, 6);
            this.GetServersButton.Name = "GetServersButton";
            this.GetServersButton.Size = new System.Drawing.Size(89, 23);
            this.GetServersButton.TabIndex = 5;
            this.GetServersButton.Text = "Get Servers";
            this.GetServersButton.UseVisualStyleBackColor = true;
            this.GetServersButton.Click += new System.EventHandler(this.GetServersButton_Click);
            // 
            // DataGrid_Players
            // 
            this.DataGrid_Players.AllowUserToAddRows = false;
            this.DataGrid_Players.AllowUserToDeleteRows = false;
            this.DataGrid_Players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Players.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.PlayerScore,
            this.PlayerTime});
            this.DataGrid_Players.Location = new System.Drawing.Point(863, 88);
            this.DataGrid_Players.Name = "DataGrid_Players";
            this.DataGrid_Players.RowHeadersVisible = false;
            this.DataGrid_Players.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_Players.Size = new System.Drawing.Size(470, 476);
            this.DataGrid_Players.TabIndex = 4;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            this.PlayerName.Width = 230;
            // 
            // PlayerScore
            // 
            this.PlayerScore.HeaderText = "Score";
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.ReadOnly = true;
            // 
            // PlayerTime
            // 
            this.PlayerTime.HeaderText = "Time";
            this.PlayerTime.Name = "PlayerTime";
            this.PlayerTime.ReadOnly = true;
            // 
            // DataGridServers
            // 
            this.DataGridServers.AllowUserToAddRows = false;
            this.DataGridServers.AllowUserToDeleteRows = false;
            this.DataGridServers.AllowUserToResizeColumns = false;
            this.DataGridServers.AllowUserToResizeRows = false;
            this.DataGridServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerIndex,
            this.ServerName,
            this.Players,
            this.Bots,
            this.ServerIP,
            this.ServerPort});
            this.DataGridServers.Location = new System.Drawing.Point(6, 88);
            this.DataGridServers.Name = "DataGridServers";
            this.DataGridServers.RowHeadersVisible = false;
            this.DataGridServers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridServers.Size = new System.Drawing.Size(851, 502);
            this.DataGridServers.TabIndex = 4;
            this.DataGridServers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridServers_CellClick);
            this.DataGridServers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridServers_CellDoubleClick);
            // 
            // ServerIndex
            // 
            this.ServerIndex.HeaderText = "Index";
            this.ServerIndex.Name = "ServerIndex";
            this.ServerIndex.ReadOnly = true;
            this.ServerIndex.Width = 50;
            // 
            // ServerName
            // 
            this.ServerName.HeaderText = "Server Name";
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            this.ServerName.Width = 497;
            // 
            // Players
            // 
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            this.Players.Width = 50;
            // 
            // Bots
            // 
            this.Bots.HeaderText = "Bots";
            this.Bots.Name = "Bots";
            this.Bots.ReadOnly = true;
            this.Bots.Width = 40;
            // 
            // ServerIP
            // 
            this.ServerIP.HeaderText = "Server IP";
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.ReadOnly = true;
            this.ServerIP.Width = 120;
            // 
            // ServerPort
            // 
            this.ServerPort.HeaderText = "Port";
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.ReadOnly = true;
            this.ServerPort.Width = 50;
            // 
            // NotEmpty_CB
            // 
            this.NotEmpty_CB.AutoSize = true;
            this.NotEmpty_CB.Location = new System.Drawing.Point(600, 64);
            this.NotEmpty_CB.Name = "NotEmpty_CB";
            this.NotEmpty_CB.Size = new System.Drawing.Size(105, 17);
            this.NotEmpty_CB.TabIndex = 3;
            this.NotEmpty_CB.Text = "Show Not Empty";
            this.NotEmpty_CB.UseVisualStyleBackColor = true;
            // 
            // HostnameTextBox
            // 
            this.HostnameTextBox.Location = new System.Drawing.Point(380, 62);
            this.HostnameTextBox.Name = "HostnameTextBox";
            this.HostnameTextBox.Size = new System.Drawing.Size(214, 20);
            this.HostnameTextBox.TabIndex = 2;
            // 
            // MapTextBox
            // 
            this.MapTextBox.Location = new System.Drawing.Point(380, 36);
            this.MapTextBox.Name = "MapTextBox";
            this.MapTextBox.Size = new System.Drawing.Size(133, 20);
            this.MapTextBox.TabIndex = 2;
            // 
            // GameComboBox
            // 
            this.GameComboBox.FormattingEnabled = true;
            this.GameComboBox.Items.AddRange(new object[] {
            "Half_Life2",
            "Counter_Strike_Source",
            "Day_Of_Defeat",
            "Half_Life2_Deathmatch",
            "Team_Fortress_2",
            "Left_4_Dead_2",
            "Counter_Strike_Global_Offensive",
            "Garrys_Mod",
            "Insurgency"});
            this.GameComboBox.Location = new System.Drawing.Point(52, 60);
            this.GameComboBox.Name = "GameComboBox";
            this.GameComboBox.Size = new System.Drawing.Size(261, 21);
            this.GameComboBox.TabIndex = 1;
            // 
            // RegionComboBox
            // 
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Items.AddRange(new object[] {
            "UsEastCoast",
            "UsWestCoast",
            "SouthAmerica",
            "Europe",
            "Asia",
            "Australia",
            "MiddleEast",
            "Africa",
            "All"});
            this.RegionComboBox.Location = new System.Drawing.Point(52, 35);
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Size = new System.Drawing.Size(261, 21);
            this.RegionComboBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1339, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Server Rules";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1339, 596);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rcon";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 646);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Players)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridServers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox RegionComboBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox GameComboBox;
        private System.Windows.Forms.CheckBox NotEmpty_CB;
        private System.Windows.Forms.TextBox HostnameTextBox;
        private System.Windows.Forms.TextBox MapTextBox;
        private System.Windows.Forms.DataGridView DataGrid_Players;
        private System.Windows.Forms.DataGridView DataGridServers;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bots;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerPort;
        private System.Windows.Forms.Button GetServersButton;
        private System.Windows.Forms.Label RegionLabel;
        private System.Windows.Forms.Label HostNameLabel;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Button StopSearch;
        private System.Windows.Forms.Label ServerIPLabel;
        private System.Windows.Forms.TextBox ServerIPTextBox;
    }
}

