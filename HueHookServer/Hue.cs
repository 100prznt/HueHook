using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rca.HueHookServer
{
    public class Hue
    {
        #region Member
        public static LocalHueClient Client;

        #endregion Member

        #region Properties

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for HueClient
        /// </summary>
        public Hue()
        {

        }

        #endregion Constructor

        #region Services

        public async void ConnectBridge(IPAddress ip, string appKey)
        {
            Client = new LocalHueClient(ip.ToString());
            Client.Initialize(appKey);

            var bridge = await Client.GetBridgeAsync();

            Console.WriteLine("Hue bridge is successfully connected.");
            Console.WriteLine("Name: {0}", bridge.Config.Name);
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
