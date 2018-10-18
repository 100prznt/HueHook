using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.HueHookService
{
    public static class InherentLogger
    {
        #region Constants
        const string LOG_FILE_NAME = "LogFile.txt";
        const string DEFAULT_LOG_PATH = @"C:\\temp\HueHook\Logs";

        #endregion Constants

        #region Member
        static bool m_LogPathExists = false;
        #endregion Member

        #region Properties

        static string m_LogPath = Path.Combine(DEFAULT_LOG_PATH, LOG_FILE_NAME);

        public static string LogPath
        {
            get
            {
                return m_LogPath;
            }
            set
            {
                SetLogPath(value);
            }
        }


        #endregion Properties

        #region Services
        public static void WriteErrorLog(Exception ex)
        {
            CheckLogPath();

            using (var sw = new StreamWriter(LogPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.Flush();
            }
        }

        public static void WriteErrorLog(string message)
        {
            CheckLogPath();

            using (var sw = new StreamWriter(LogPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + message);
                sw.Flush();
            }
        }

        #endregion Services

        #region Internal services
        static void CheckLogPath()
        {
            if (!m_LogPathExists)
                SetLogPath();
        }

        static void SetLogPath(string path = DEFAULT_LOG_PATH)
        {
            try
            {
                var logDir = path;
                if (Path.HasExtension(path))
                    logDir = Path.GetDirectoryName(path);

                if (!string.IsNullOrWhiteSpace(logDir) && !Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                m_LogPath = Path.Combine(path, LOG_FILE_NAME);
            }
            catch (Exception)
            {
                if (!Directory.Exists(DEFAULT_LOG_PATH))
                    Directory.CreateDirectory(DEFAULT_LOG_PATH);

                m_LogPath = Path.Combine(DEFAULT_LOG_PATH, LOG_FILE_NAME);
            }

            m_LogPathExists = true;
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
