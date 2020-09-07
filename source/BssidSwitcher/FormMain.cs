using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using NativeWifi;

namespace BssidSwitcher
{
    public partial class FormMain : Form
    {
        private class NetworkListColumnSorter : IComparer
        {
            public int ColumnToSort { get; set; } = -1;
            public SortOrder SortingOrder { get; set; }

            private IComparer stringComparer = new CaseInsensitiveComparer();

            public int Compare(object rx, object ry)
            {
                return InternalCompare(rx, ry) * (SortingOrder == SortOrder.Ascending ? 1 : -1);
            }

            private int InternalCompare(object rx, object ry)
            {
                if(ColumnToSort < 0)
                    return 0;
                var lx = (ListViewItem)rx;
                var ly = (ListViewItem)ry;
                if(ColumnToSort == 0)
                {
                    var cx = (WifiNetwork)lx.Tag;
                    var cy = (WifiNetwork)ly.Tag;
                    return (int)cx.LinkQuality - (int)cy.LinkQuality;
                }
                return stringComparer.Compare(lx.SubItems[ColumnToSort].Text, ly.SubItems[ColumnToSort].Text);
            }
        }

        NativeWifiManager wifiMan_;
        WifiNetwork[] availNetworks_ = null;
        FormMainUiState stateHelper_;
        NetworkListColumnSorter networkListColumnSorter_ = new NetworkListColumnSorter();
        List<ListViewItem> currentNetworkList_ = new List<ListViewItem>();
        ListViewItem connectedNet_ = null;
        private ListViewItem ConnectedNetworkItemList
        {
            get { return connectedNet_; }
            set
            {
                // unbold old font
                if(connectedNet_ != null)
                {
                    connectedNet_.Font = listNetworks.Font;
                }
                connectedNet_ = value;
                if(value != null)
                {
                    value.Font = new Font(listNetworks.Font, FontStyle.Bold);
                }
            }
        }
        
        public FormMain()
        {
            stateHelper_ = new FormMainUiState(this);
            InitializeComponent();
            listNetworks.ListViewItemSorter = networkListColumnSorter_;
            ConfigureBindings();
        }

        private void ConfigureBindings()
        {
            labelFilteredNetworks.DataBindings.Add(new Binding("Visible", toggleFilter, "Checked"));
            progressIndicator.ProgressBar.DataBindings.Add(new Binding("Visible", stateHelper_, "HasActivity"));
            listInterfaces.DataBindings.Add(new Binding("SelectedItem", stateHelper_, "SelectedInterface"));
            buttonRescan.DataBindings.Add(new Binding("Enabled", stateHelper_, "EnableUIElements"));
            buttonConnect.DataBindings.Add(new Binding("Enabled", stateHelper_, "EnableUIElements"));
            listInterfaces.DataBindings.Add(new Binding("Enabled", stateHelper_, "HasNoActivity"));
        }

        private void UpdateStateIndicator(InterfaceState state)
        {
            switch(state)
            {
                case NativeWifi.InterfaceState.AdHocNetworkFormed:
                    labelNetworkState.Text = "Ad-Hoc (IBSS)";
                    break;
                case NativeWifi.InterfaceState.Associating:
                    labelNetworkState.Text = "Associating...";
                    break;
                case NativeWifi.InterfaceState.Authenticating:
                    labelNetworkState.Text = "Authenticating...";
                    break;
                case NativeWifi.InterfaceState.Connected:
                    labelNetworkState.Text = "Connected";
                    break;
                case NativeWifi.InterfaceState.Disconnected:
                    labelNetworkState.Text = "Disconnected";
                    break;
                case NativeWifi.InterfaceState.Disconnecting:
                    labelNetworkState.Text = "Disconnecting...";
                    break;
                case NativeWifi.InterfaceState.Discovering:
                    labelNetworkState.Text = "Discovering...";
                    break;
                case NativeWifi.InterfaceState.NotReady:
                    labelNetworkState.Text = "Wi-Fi not ready";
                    break;
                default:
                    labelNetworkState.Text = "(Unknown state)";
                    break;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(!RunAndHandleEx(() => { wifiMan_ = new NativeWifiManager(); }))
            {
                MessageBox.Show("Startup failed. Application will close.", "Startup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            wifiMan_.OnWifiAcm += WifiMan__OnWifiAcm;
            UpdateInterfaceList();
        }

        private void WifiMan__OnWifiAcm(WifiAcmNotificationCode code, object data)
        {
            Utils.RunInUIThread(this, () => { WifiMan_OnWifiAcm_UIThread(code); });
        }

        private void WifiMan_OnWifiAcm_UIThread(WifiAcmNotificationCode code)
        {
            switch(code)
            {
                case WifiAcmNotificationCode.ScanFail:
                case WifiAcmNotificationCode.ScanComplete:
                    ScanCompleteAction();
                    break;
                case WifiAcmNotificationCode.ConnectionComplete:
                case WifiAcmNotificationCode.ConnectionStart:
                case WifiAcmNotificationCode.Disconnecting:
                case WifiAcmNotificationCode.Disconnected:
                case WifiAcmNotificationCode.ConnectionAttemptFail:
                    UpdateInterfaceStateInfo();
                    break;
                case WifiAcmNotificationCode.InterfaceArrival:
                case WifiAcmNotificationCode.InterfaceRemoval:
                    UpdateInterfaceList();
                    break;
            }
        }

        private void buttonEditFilter_Click(object sender, EventArgs e)
        {
            new FormEditFilter().ShowDialog();
            ShowFilteredNetworks();
        }

        private void UpdateInterfaceList()
        {
            listInterfaces.Items.Clear();
            RunAndHandleEx(() => { listInterfaces.Items.AddRange(wifiMan_.EnumInterfaces()); });
            if(listInterfaces.Items.Count > 0)
            {
                listInterfaces.SelectedIndex = 0;
            }
        }

        private void UpdateNetworkList()
        {
            availNetworks_ = null;
            RunAndHandleEx(() => { availNetworks_ = wifiMan_.GetAvailableNetworks((InterfaceInfo)listInterfaces.SelectedItem); });
            Func<WifiNetwork, ListViewItem> listItemGenerator = (WifiNetwork net) =>
            {
                var ret = new ListViewItem(new string[] { $"{net.LinkQuality}%", net.SSID, Utils.MacStringify(net.BSSID), $"{net.CenterFrequency / 1000}" });
                ret.Tag = net;
                return ret;
            };
            ConnectedNetworkItemList = null;
            if(availNetworks_ != null)
            {
                currentNetworkList_.Clear();
                currentNetworkList_.AddRange((from net in availNetworks_ select listItemGenerator(net)));
                UpdateInterfaceStateInfo();
                ShowFilteredNetworks();
            }
            else
                MessageBox.Show("Network list update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ScanCompleteAction()
        {
            UpdateNetworkList();
            stateHelper_.IsScanning = false;
        }

        private void UpdateInterfaceStateInfo()
        {
            InterfaceInfo iface = (InterfaceInfo)listInterfaces.SelectedItem;
            if(iface == null)
            {
                ConnectedNetworkItemList = null;
                return;
            }
            UpdateStateIndicator(iface.State);
            ConnectionInfo currConn = null;
            try { currConn = iface.CurrentConnection; }
            catch(Exception) { }
            if(currConn != null)
            {
                var currConnUi = ConnectedNetworkItemList;
                if(currConnUi != null)
                {
                    // check similarity
                    WifiNetwork currConnUiNet = (WifiNetwork)currConnUi.Tag;
                    if(!(currConnUiNet.BSSID.SequenceEqual(currConn.BSSID) &&
                        currConnUiNet.ProfileName == currConn.ProfileName))
                    {
                        UpdateConnectedNetworkList(currConn);
                    }
                }
                else
                    UpdateConnectedNetworkList(currConn);
            }
            else
                UpdateConnectedNetworkList(null);
        }

        private void ShowFilteredNetworks()
        {
            listNetworks.Items.Clear();
            if(toggleFilter.Checked)
            {
                var filteredNetwork = (from itemList in currentNetworkList_
                                      where Filter.Instance.Match((WifiNetwork)itemList.Tag)
                                      select itemList).ToArray();
                listNetworks.Items.AddRange(filteredNetwork);
                labelFilteredNetworks.Text = $"({filteredNetwork.Length} of {currentNetworkList_.Count} networks filtered)";
            }
            else
                listNetworks.Items.AddRange(currentNetworkList_.ToArray());

            for(int i=0; i<listNetworks.Columns.Count; ++i)
            {
                listNetworks.Columns[i].Width = -2;
            }
        }

        private void UpdateConnectedNetworkList(ConnectionInfo ci)
        {
            if(ci != null)
            {
                Filter.Instance.ConnectedProfileName = ci.ProfileName;
                foreach(var itemList in currentNetworkList_)
                {
                    WifiNetwork currConnUiNet = (WifiNetwork)itemList.Tag;
                    if(currConnUiNet.BSSID.SequenceEqual(ci.BSSID) &&
                        currConnUiNet.ProfileName == ci.ProfileName)
                    {
                        ConnectedNetworkItemList = itemList;
                        return;
                    }
                }
            }
            else
                Filter.Instance.ConnectedProfileName = null;
            ConnectedNetworkItemList = null;
        }

        private static bool RunAndHandleEx(Action action)
        {
            try
            {
                action();
            } 
            catch(InvalidHandleException)
            {
                MessageBox.Show("Invalid handle to WLAN API.", "Invalid Handle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(NativeWifiException ex)
            {
                MessageBox.Show($"Native WLAN API operation failed with error code {ex.ErrorCode}.", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Exception ocurred: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void buttonRescan_Click(object sender, EventArgs e)
        {
            var iface = (InterfaceInfo)listInterfaces.SelectedItem;
            if(iface != null)
            {
                wifiMan_.TriggerScan(iface);
                stateHelper_.IsScanning = true;
            }
        }

        private void listNetworks_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonConnect.Enabled = listNetworks.SelectedIndices.Count > 0;
        }

        private void listNetworks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var listSender = (ListView)sender;
            if(networkListColumnSorter_.ColumnToSort == e.Column)
            {
                networkListColumnSorter_.SortingOrder = networkListColumnSorter_.SortingOrder == SortOrder.Ascending 
                    ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                networkListColumnSorter_.SortingOrder = SortOrder.Ascending;
                networkListColumnSorter_.ColumnToSort = e.Column;
            }
            listSender.Sort();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            InterfaceInfo iface = (InterfaceInfo)listInterfaces.SelectedItem;
            WifiNetwork network = (WifiNetwork)(listNetworks.SelectedItems.Count > 0 ? listNetworks.SelectedItems[0].Tag : null);
            if(iface == null || network == null)
            {
                MessageBox.Show("Please select a network interface and Wi-Fi network to connect.", "Nothing to Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(network.ProfileName == null)
            {
                MessageBox.Show("A profile has not been configured for this network yet. Please connect to this network using Windows' built-in Wi-Fi manager or create a new profile first.",
                    "Profile Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                wifiMan_.Connect(iface, network);
            }
            catch(Exception)
            {
                MessageBox.Show("Error connecting to network. Try to run this program as administrator.", "Error Initialising Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cSender = (ComboBox)sender;
            if(cSender.SelectedIndex >= 0)
            {
                stateHelper_.SelectedInterface = listInterfaces.SelectedItem;
                UpdateNetworkList();
                UpdateInterfaceStateInfo();
            }
        }

        private void toggleFilter_CheckedChanged(object sender, EventArgs e)
        {
            ShowFilteredNetworks();
        }
    }
}
