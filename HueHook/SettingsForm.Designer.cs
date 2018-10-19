namespace Rca.HueHook
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BridgeIp = new System.Windows.Forms.TextBox();
            this.txt_BridgeUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ServerPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ServerIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_WhitListIps = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_EnableWhitelist = new System.Windows.Forms.CheckBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address";
            // 
            // txt_BridgeIp
            // 
            this.txt_BridgeIp.Location = new System.Drawing.Point(109, 29);
            this.txt_BridgeIp.Name = "txt_BridgeIp";
            this.txt_BridgeIp.Size = new System.Drawing.Size(184, 20);
            this.txt_BridgeIp.TabIndex = 1;
            // 
            // txt_BridgeUser
            // 
            this.txt_BridgeUser.Location = new System.Drawing.Point(109, 55);
            this.txt_BridgeUser.Name = "txt_BridgeUser";
            this.txt_BridgeUser.Size = new System.Drawing.Size(184, 20);
            this.txt_BridgeUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User";
            // 
            // txt_ServerPort
            // 
            this.txt_ServerPort.Location = new System.Drawing.Point(112, 58);
            this.txt_ServerPort.Name = "txt_ServerPort";
            this.txt_ServerPort.Size = new System.Drawing.Size(184, 20);
            this.txt_ServerPort.TabIndex = 7;
            this.txt_ServerPort.Text = "8008";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // txt_ServerIp
            // 
            this.txt_ServerIp.Location = new System.Drawing.Point(112, 32);
            this.txt_ServerIp.Name = "txt_ServerIp";
            this.txt_ServerIp.Size = new System.Drawing.Size(184, 20);
            this.txt_ServerIp.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "IP address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_BridgeIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_BridgeUser);
            this.groupBox1.Location = new System.Drawing.Point(27, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Philips Hue Bridge";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_ServerPort);
            this.groupBox2.Controls.Add(this.txt_ServerIp);
            this.groupBox2.Location = new System.Drawing.Point(27, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local server";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_WhitListIps);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbx_EnableWhitelist);
            this.groupBox3.Location = new System.Drawing.Point(373, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 232);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Whitelist";
            // 
            // txt_WhitListIps
            // 
            this.txt_WhitListIps.Location = new System.Drawing.Point(52, 78);
            this.txt_WhitListIps.Multiline = true;
            this.txt_WhitListIps.Name = "txt_WhitListIps";
            this.txt_WhitListIps.Size = new System.Drawing.Size(173, 132);
            this.txt_WhitListIps.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "IP addresses (each per line)";
            // 
            // cbx_EnableWhitelist
            // 
            this.cbx_EnableWhitelist.AutoSize = true;
            this.cbx_EnableWhitelist.Checked = true;
            this.cbx_EnableWhitelist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_EnableWhitelist.Location = new System.Drawing.Point(53, 28);
            this.cbx_EnableWhitelist.Name = "cbx_EnableWhitelist";
            this.cbx_EnableWhitelist.Size = new System.Drawing.Size(99, 17);
            this.cbx_EnableWhitelist.TabIndex = 11;
            this.cbx_EnableWhitelist.Text = "Enable whitelist";
            this.cbx_EnableWhitelist.UseVisualStyleBackColor = true;
            this.cbx_EnableWhitelist.CheckedChanged += new System.EventHandler(this.cbx_EnableWhitelist_CheckedChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(547, 274);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(466, 274);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(649, 319);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "HueHook Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_BridgeIp;
        private System.Windows.Forms.TextBox txt_BridgeUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ServerPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ServerIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_WhitListIps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbx_EnableWhitelist;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
    }
}