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
        #region Member


        #endregion Member

        #region Properties


        #endregion Properties

        #region Services
        public static void WriteErrorLog(Exception ex)
        {
            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.Flush();
            }
        }

        public static void WriteErrorLog(string message)
        {
            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + message);
                sw.Flush();
            }
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
