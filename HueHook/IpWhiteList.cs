using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.HueHook
{
    [Serializable]
    public class IpWhiteList
    {
        #region Member


        #endregion Member

        #region Properties
        [XmlIgnore]
        public IPAddress[] IpAddresses { get; set; }
        
        [XmlElement("IpAddress")]
        public string[] IpAddressesString
        {
            get
            {
                return IpAddresses.Select(x => x.ToString()).ToArray();
            }
            set
            {
                IpAddresses = value.Select(x => IPAddress.Parse(x)).ToArray();
            }
        }


        #endregion Properties

        #region Services
        public bool IsWhitelisted(IPAddress ip)
        {
            return IpAddresses.Any(x => x.Equals(ip));
        }

        public void AddIp(IPAddress ip)
        {
            var ips = IpAddresses.ToList();
            ips.Add(ip);

            IpAddresses = ips.ToArray();
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
