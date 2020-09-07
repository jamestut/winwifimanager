namespace BssidSwitcher
{
    partial class FormMain
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.interfaceSelectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRescan = new System.Windows.Forms.Button();
            this.listInterfaces = new System.Windows.Forms.ComboBox();
            this.commandsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toggleFilter = new System.Windows.Forms.CheckBox();
            this.buttonEditFilter = new System.Windows.Forms.Button();
            this.labelFilteredNetworks = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelNetworkState = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressIndicator = new System.Windows.Forms.ToolStripProgressBar();
            this.listNetworks = new System.Windows.Forms.ListView();
            this.colSignalStrength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBSSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainLayout.SuspendLayout();
            this.interfaceSelectionLayout.SuspendLayout();
            this.commandsLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.interfaceSelectionLayout, 0, 0);
            this.mainLayout.Controls.Add(this.commandsLayout, 0, 2);
            this.mainLayout.Controls.Add(this.statusStrip1, 0, 3);
            this.mainLayout.Controls.Add(this.listNetworks, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(7);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(1204, 781);
            this.mainLayout.TabIndex = 0;
            // 
            // interfaceSelectionLayout
            // 
            this.interfaceSelectionLayout.AutoSize = true;
            this.interfaceSelectionLayout.ColumnCount = 2;
            this.interfaceSelectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.interfaceSelectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.interfaceSelectionLayout.Controls.Add(this.buttonRescan, 1, 0);
            this.interfaceSelectionLayout.Controls.Add(this.listInterfaces, 0, 0);
            this.interfaceSelectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceSelectionLayout.Location = new System.Drawing.Point(7, 7);
            this.interfaceSelectionLayout.Margin = new System.Windows.Forms.Padding(7);
            this.interfaceSelectionLayout.Name = "interfaceSelectionLayout";
            this.interfaceSelectionLayout.RowCount = 1;
            this.interfaceSelectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.interfaceSelectionLayout.Size = new System.Drawing.Size(1190, 65);
            this.interfaceSelectionLayout.TabIndex = 1;
            // 
            // buttonRescan
            // 
            this.buttonRescan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRescan.Location = new System.Drawing.Point(1008, 7);
            this.buttonRescan.Margin = new System.Windows.Forms.Padding(7);
            this.buttonRescan.Name = "buttonRescan";
            this.buttonRescan.Size = new System.Drawing.Size(175, 51);
            this.buttonRescan.TabIndex = 0;
            this.buttonRescan.Text = "&Rescan";
            this.buttonRescan.UseVisualStyleBackColor = true;
            this.buttonRescan.Click += new System.EventHandler(this.buttonRescan_Click);
            // 
            // listInterfaces
            // 
            this.listInterfaces.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listInterfaces.FormattingEnabled = true;
            this.listInterfaces.Location = new System.Drawing.Point(9, 14);
            this.listInterfaces.Margin = new System.Windows.Forms.Padding(7);
            this.listInterfaces.Name = "listInterfaces";
            this.listInterfaces.Size = new System.Drawing.Size(982, 37);
            this.listInterfaces.TabIndex = 0;
            this.listInterfaces.SelectedIndexChanged += new System.EventHandler(this.listInterfaces_SelectedIndexChanged);
            // 
            // commandsLayout
            // 
            this.commandsLayout.AutoSize = true;
            this.commandsLayout.ColumnCount = 2;
            this.commandsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.commandsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.commandsLayout.Controls.Add(this.buttonConnect, 1, 0);
            this.commandsLayout.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.commandsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsLayout.Location = new System.Drawing.Point(7, 645);
            this.commandsLayout.Margin = new System.Windows.Forms.Padding(7);
            this.commandsLayout.Name = "commandsLayout";
            this.commandsLayout.RowCount = 1;
            this.commandsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandsLayout.Size = new System.Drawing.Size(1190, 79);
            this.commandsLayout.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(1008, 14);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(7);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(175, 51);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "&Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.toggleFilter);
            this.flowLayoutPanel1.Controls.Add(this.buttonEditFilter);
            this.flowLayoutPanel1.Controls.Add(this.labelFilteredNetworks);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(987, 65);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // toggleFilter
            // 
            this.toggleFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toggleFilter.AutoSize = true;
            this.toggleFilter.Location = new System.Drawing.Point(7, 16);
            this.toggleFilter.Margin = new System.Windows.Forms.Padding(7);
            this.toggleFilter.Name = "toggleFilter";
            this.toggleFilter.Size = new System.Drawing.Size(189, 33);
            this.toggleFilter.TabIndex = 4;
            this.toggleFilter.Text = "Activate &Filter";
            this.toggleFilter.UseVisualStyleBackColor = true;
            this.toggleFilter.CheckedChanged += new System.EventHandler(this.toggleFilter_CheckedChanged);
            // 
            // buttonEditFilter
            // 
            this.buttonEditFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEditFilter.Location = new System.Drawing.Point(210, 7);
            this.buttonEditFilter.Margin = new System.Windows.Forms.Padding(7);
            this.buttonEditFilter.Name = "buttonEditFilter";
            this.buttonEditFilter.Size = new System.Drawing.Size(222, 51);
            this.buttonEditFilter.TabIndex = 3;
            this.buttonEditFilter.Text = "&Edit Filter";
            this.buttonEditFilter.UseVisualStyleBackColor = true;
            this.buttonEditFilter.Click += new System.EventHandler(this.buttonEditFilter_Click);
            // 
            // labelFilteredNetworks
            // 
            this.labelFilteredNetworks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFilteredNetworks.AutoSize = true;
            this.labelFilteredNetworks.Location = new System.Drawing.Point(446, 18);
            this.labelFilteredNetworks.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelFilteredNetworks.Name = "labelFilteredNetworks";
            this.labelFilteredNetworks.Size = new System.Drawing.Size(296, 29);
            this.labelFilteredNetworks.TabIndex = 5;
            this.labelFilteredNetworks.Text = "(0 of 100 networks filtered)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelNetworkState,
            this.labelSeparator1,
            this.progressIndicator});
            this.statusStrip1.Location = new System.Drawing.Point(0, 731);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 33, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1204, 50);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelNetworkState
            // 
            this.labelNetworkState.Name = "labelNetworkState";
            this.labelNetworkState.Size = new System.Drawing.Size(184, 39);
            this.labelNetworkState.Text = "Network State";
            // 
            // labelSeparator1
            // 
            this.labelSeparator1.Name = "labelSeparator1";
            this.labelSeparator1.Size = new System.Drawing.Size(748, 39);
            this.labelSeparator1.Spring = true;
            // 
            // progressIndicator
            // 
            this.progressIndicator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.Size = new System.Drawing.Size(233, 36);
            this.progressIndicator.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // listNetworks
            // 
            this.listNetworks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSignalStrength,
            this.colSSID,
            this.colBSSID,
            this.colFreq});
            this.listNetworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listNetworks.FullRowSelect = true;
            this.listNetworks.HideSelection = false;
            this.listNetworks.Location = new System.Drawing.Point(7, 86);
            this.listNetworks.Margin = new System.Windows.Forms.Padding(7);
            this.listNetworks.MultiSelect = false;
            this.listNetworks.Name = "listNetworks";
            this.listNetworks.Size = new System.Drawing.Size(1190, 545);
            this.listNetworks.TabIndex = 3;
            this.listNetworks.UseCompatibleStateImageBehavior = false;
            this.listNetworks.View = System.Windows.Forms.View.Details;
            this.listNetworks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listNetworks_ColumnClick);
            this.listNetworks.SelectedIndexChanged += new System.EventHandler(this.listNetworks_SelectedIndexChanged);
            // 
            // colSignalStrength
            // 
            this.colSignalStrength.Text = "%";
            this.colSignalStrength.Width = 40;
            // 
            // colSSID
            // 
            this.colSSID.Text = "SSID";
            this.colSSID.Width = 250;
            // 
            // colBSSID
            // 
            this.colBSSID.Text = "BSSID";
            this.colBSSID.Width = 150;
            // 
            // colFreq
            // 
            this.colFreq.Text = "Freq MHz";
            this.colFreq.Width = 75;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 781);
            this.Controls.Add(this.mainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MinimumSize = new System.Drawing.Size(1183, 648);
            this.Name = "FormMain";
            this.Text = "Wi-Fi Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.interfaceSelectionLayout.ResumeLayout(false);
            this.commandsLayout.ResumeLayout(false);
            this.commandsLayout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelNetworkState;
        private System.Windows.Forms.ToolStripProgressBar progressIndicator;
        private System.Windows.Forms.TableLayoutPanel interfaceSelectionLayout;
        private System.Windows.Forms.Button buttonRescan;
        private System.Windows.Forms.ComboBox listInterfaces;
        private System.Windows.Forms.ToolStripStatusLabel labelSeparator1;
        private System.Windows.Forms.TableLayoutPanel commandsLayout;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonEditFilter;
        private System.Windows.Forms.CheckBox toggleFilter;
        private System.Windows.Forms.ListView listNetworks;
        private System.Windows.Forms.ColumnHeader colSignalStrength;
        private System.Windows.Forms.ColumnHeader colSSID;
        private System.Windows.Forms.ColumnHeader colBSSID;
        private System.Windows.Forms.ColumnHeader colFreq;
        private System.Windows.Forms.Label labelFilteredNetworks;
    }
}