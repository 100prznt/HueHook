using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rca.HueHookServer
{
    public static class Whitelist
    {
        #region Member


        #endregion Member

        #region Properties
        public static IPAddress[] IpAddresses { get; set; }

        #endregion Properties

        #region Services
        public static void Init(string path)
        {
            IpAddresses = GetIpsFromFile(path);
        }

        public static bool IsWhitelisted(IPAddress ip)
        {
            return IpAddresses.Any(x => x.Equals(ip));
        }

        public static void AddIp(IPAddress ip)
        {
            var ips = IpAddresses.ToList();
            ips.Add(ip);

            IpAddresses = ips.ToArray();
        }

        public static IPAddress[] GetIpsFromFile(string path)
        {
            if (File.Exists(path))
            {
                var fs = new FileStream(path, FileMode.Open);
                var sr = new StreamReader(fs);

                var ips = new List<IPAddress>();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    IPAddress ip = null;
                    if (IPAddress.TryParse(line, out ip))
                        ips.Add(ip);
                }

                return ips.ToArray();
            }
            else
                return new IPAddress[0];
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
