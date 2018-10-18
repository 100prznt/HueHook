using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.HueHook
{
    public partial class SettingsForm : Form
    {
        public HueHookSettings Settings { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        public void ApplyData(HueHookSettings settings)
        {
            Settings = settings;

            if (Settings != null)
            {
                txt_BridgeIp.Text = Settings.BridgeIp.ToString();
                txt_BridgeUser.Text = Settings.BridgeUsername;
                txt_ServerIp.Text = Settings.LocalServerIp.ToString();
                txt_ServerPort.Text = Settings.LocalServerPort.ToString();
                cbx_EnableWhitelist.Checked = !Settings.WhiteList.Disabled;
                txt_WhitListIps.Enabled = !Settings.WhiteList.Disabled;
                foreach (var ip in Settings.WhiteList.IpAddresses)
                    txt_WhitListIps.AppendText(ip.ToString() + "\n");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            IPAddress bridgeIp;
            IPAddress serverIp;
            int serverPort;
            IPAddress whiteListIp;
            List<IPAddress> whiteListIps = new List<IPAddress>(); ;

            if (!IPAddress.TryParse(txt_BridgeIp.Text, out bridgeIp))
            {
                MessageBox.Show("IP address for Philips Hue Bridge is invalid.", "Check input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            if (!IPAddress.TryParse(txt_ServerIp.Text, out serverIp))
            { 
                MessageBox.Show("IP address for the local server is invalid.", "Check input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt_ServerPort.Text, out serverPort))
            {
                MessageBox.Show("Port for the local server is invalid.", "Check input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var ip in txt_WhitListIps.Lines)
            {
                if (string.IsNullOrWhiteSpace(ip))
                    continue;

                if (IPAddress.TryParse(ip, out whiteListIp))
                    whiteListIps.Add(whiteListIp);
                else
                {
                    MessageBox.Show("IP address (" + ip + ") for whitelist is invalid.", "Check input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (Settings == null)
                Settings = new HueHookSettings();

            Settings.BridgeIp = bridgeIp;
            Settings.BridgeUsername = txt_BridgeUser.Text.Trim();
            Settings.LocalServerIp = serverIp;
            Settings.LocalServerPort = serverPort;
            Settings.WhiteList.Disabled = !cbx_EnableWhitelist.Checked;
            Settings.WhiteList.IpAddresses = whiteListIps.ToArray();

            this.Close();
        }

        private void cbx_EnableWhitelist_CheckedChanged(object sender, EventArgs e)
        {
            txt_WhitListIps.Enabled = cbx_EnableWhitelist.Checked;
        }
    }
}
