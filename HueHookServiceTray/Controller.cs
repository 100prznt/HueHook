using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace Rca.HueHookServiceTray
{
    public class Controller : INotifyPropertyChanged
    {
        #region Member
        ServiceController m_HueHookService;

        #endregion Member

        #region Properties
        public bool ServiceIsRunning
        {
            get
            {
                return m_ServiceIsRunning;
            }
            set
            {
                PropChanged();
                m_ServiceIsRunning = value;
            }
        }
        bool m_ServiceIsRunning;

        private bool m_ServiceConnected;

        public bool ServiceConnected
        {
            get
            {
                return m_ServiceConnected;
            }
            set
            {
                PropChanged();
                m_ServiceConnected = value;
            }
        }


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for Controller
        /// </summary>
        public Controller()
        {

        }

        #endregion Constructor

        #region Services
        /// <summary>
        /// Bind the service to this controller
        /// </summary>
        /// <param name="updateStatus">Update status, after binding</param>
        /// <returns>Service successful binded</returns>
        public bool AppendToService(bool updateStatus = true)
        {
            //Check service state
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.ServiceName == "HueHookServer")
                {
                    m_HueHookService = new ServiceController("HueHookServer");

                    if (updateStatus)
                        UpdateStatus();
                    ServiceConnected = true;
                    return true;
                }
            }

            m_HueHookService = null;
            ServiceConnected = false;
            return false;
        }

        public void UpdateStatus()
        {
            if (m_HueHookService != null)
            {
                m_HueHookService.Refresh();
                ServiceIsRunning = m_HueHookService.Status == ServiceControllerStatus.Running || m_HueHookService.Status == ServiceControllerStatus.ContinuePending;
            }
            else
            {
                ServiceIsRunning = false;
                ServiceConnected = false;
            }
        }

        /// <summary>
        /// Stop the service
        /// </summary>
        internal void Stop()
        {
            if (m_HueHookService != null && m_HueHookService.Status == ServiceControllerStatus.Running)
            {
                m_HueHookService.Stop();
                m_HueHookService.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10.0));
            }
        }

        /// <summary>
        /// Start the service
        /// </summary>
        internal void Start()
        {
            if (m_HueHookService != null && m_HueHookService.Status == ServiceControllerStatus.Stopped)
            {
                var args = new string[1]{ @"C:\temp\HueHook\Settings.xml" };

                m_HueHookService.Start(args);
                m_HueHookService.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10.0));
            }
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events

        #region INotifyPropertyChanged Member
        /// <summary>
        /// Helpmethod, to call the <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propName">Name of changed property</param>
        protected void PropChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Updated property values available
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
