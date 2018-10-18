using SmartHttpServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace Rca.HueHookService
{
    public partial class HueHookServer : ServiceBase
    {
        Controller m_Controller;
        string m_SettingsPath;

        public HueHookServer(string[] args)
        {
            InitializeComponent();

            //if (args.Length < 1)
            //    throw new ArgumentException("Missing startparameter [1], contains the path to settings file!");
            //else
            //    m_SettingsPath = args[0];

            //if (args.Length > 1)
            //    InherentLogger.SetLogPath(args[1]);

            //m_SettingsPath = "C:\\temp\\HueHook\\Settings.xml";
            //InherentLogger.SetLogPath("C:\\temp\\HueHook");


            m_Controller = new Controller();
            
        }

        protected override void OnStart(string[] args)
        {
            InherentLogger.WriteErrorLog("Start HueHookServer");
            for (int i = 0; i < args.Length; i++)
                InherentLogger.WriteErrorLog("arg[" + (i + 1) + "] = " + args[i]);

            if (args.Length == 1 && File.Exists(args[0]))
                m_SettingsPath = args[0];
            else
                InherentLogger.WriteErrorLog("Can not found settings file!");

            try
            {
                m_Controller.LoadSettings(m_SettingsPath);
            }
            catch (Exception ex)
            {
                InherentLogger.WriteErrorLog(ex);
            }

            InherentLogger.WriteErrorLog("Settings loaded");
            InherentLogger.WriteErrorLog("Log path: " + Controller.Settings.LogPath);
            InherentLogger.LogPath = Controller.Settings.LogPath;
            InherentLogger.WriteErrorLog("Log path is setted");


            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            


            // Set up a timer that triggers every minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000; // 10 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();



            InherentLogger.WriteErrorLog("Try to start HTTP server");
            try
            {
                HttpServer httpServer = new HookReceiver(Controller.Settings.LocalServerIp, Controller.Settings.LocalServerPort);
    
                Thread thread = new Thread(new ThreadStart(httpServer.listen));
                thread.Start();
                InherentLogger.WriteErrorLog("HTTP server is started");
            }
            catch (Exception ex)
            {
                InherentLogger.WriteErrorLog(ex);
            }



            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            InherentLogger.WriteErrorLog("Stop HueHookServer");

            // Update the service state to Stop Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            





            //Update the service state to Stopped.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }


        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            InherentLogger.WriteErrorLog("HueHookServer is alive");
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);
    }

    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    };
}
