using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.HueHookServiceTray
{
    public class ProcessIcon : IDisposable
    {
        #region Member
        
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;

        /// <summary>
        /// Main controller
        /// </summary>
        Controller m_Controller;

        #endregion Member

        #region Properties


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for ProcessIcon
        /// </summary>
        public ProcessIcon()
        {
            m_Controller = new Controller();
            m_Controller.AppendToService();

            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();

            m_Controller.PropertyChanged += new PropertyChangedEventHandler(Controller_PropertyChanged);
        }

        private void Controller_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Controller.ServiceIsRunning) && ni.ContextMenuStrip != null)
            {
                ni.ContextMenuStrip.Items["stop"].Enabled = m_Controller.ServiceIsRunning;
                ni.ContextMenuStrip.Items["start"].Enabled = !m_Controller.ServiceIsRunning;

                ni.ContextMenuStrip.Refresh();
            }
            if (e.PropertyName == nameof(Controller.ServiceConnected) && ni.ContextMenuStrip != null)
            {
                if (m_Controller.ServiceConnected)
                {
                    ni.ContextMenuStrip.Items["stop"].Enabled = m_Controller.ServiceIsRunning;
                    ni.ContextMenuStrip.Items["start"].Enabled = !m_Controller.ServiceIsRunning;
                }
                else
                {
                    ni.ContextMenuStrip.Items["stop"].Enabled = false;
                    ni.ContextMenuStrip.Items["start"].Enabled = false;
                }

                ni.ContextMenuStrip.Refresh();
                //ni.ContextMenuStrip.Update();
            }
        }

        #endregion Constructor

        #region Services

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            //Force start with admin privileges
            //string[] CommandLineArgs = Environment.GetCommandLineArgs();
            //if (CommandLineArgs.Length <= 1 || CommandLineArgs[1] != "restarted")
            //{
            //    var processInfo = new ProcessStartInfo(Application.ExecutablePath, "restarted");
            //    processInfo.Verb = "runas";
            //    Process.Start(processInfo);
            //}
            //else
            //    Environment.Exit(0);


            // Put the icon in the system tray and allow it react to mouse clicks.			
            //ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Properties.Resource.bulb_black;
            ni.Text = "HueHookServer";
            ni.Visible = true;

            // Attach a context menu.
            ni.ContextMenuStrip = new ContextMenus().Create();
            ni.MouseMove += Ni_MouseMove;
            ni.ContextMenuStrip.Items["start"].Click += Start_Click;
            ni.ContextMenuStrip.Items["stop"].Click += Stop_Click;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            m_Controller.Stop();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            m_Controller.Start();
        }

        private void Ni_MouseMove(object sender, MouseEventArgs e)
        {
            m_Controller.UpdateStatus();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }
        #endregion Services

        #region Internal services
		void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // nop
            }
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
