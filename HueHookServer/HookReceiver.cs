using Q42.HueApi;
using SmartHttpServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Rca.HueHookServer
{
    public class HookReceiver : HttpServer
    {
        #region Member


        #endregion Member

        #region Properties

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for HookReceiver
        /// </summary>
        public HookReceiver(IPAddress ip, int port)
            : base(ip, port)
        {

        }

        #endregion Constructor

        #region Services
        /// <summary>
        /// Handle a GET request
        /// </summary>
        /// <param name="p">HTTP handler</param>
        public override void HandleGetRequest(HttpProcessor p)
        {
            try
            {
                if (p.HttpUrl.StartsWith("/light.hue"))
                {
                    //parsing GET parameters
                    var parameters = HttpUtility.ParseQueryString(p.HttpUrl.Split('?').Last());

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Call for hue-light with id: {0}", parameters["id"]);
                    Console.ResetColor();

                    var cmd = new LightCommand();
                    cmd.On = bool.Parse(parameters["on"]);

                    Hue.Client.SendCommandAsync(cmd, new List<string>() { parameters["id"] });
                }
                else if (p.HttpUrl.StartsWith("/group.hue"))
                {
                    throw new NotImplementedException();
                    //parsing GET parameters
                    var parameters = HttpUtility.ParseQueryString(p.HttpUrl.Split('?').Last());

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Call for hue-group with id: {0}", parameters["id"]);
                    Console.ResetColor();
                }
                else if (p.HttpUrl.StartsWith("/scene.hue"))
                {
                    throw new NotImplementedException();
                    //parsing GET parameters
                    var parameters = HttpUtility.ParseQueryString(p.HttpUrl.Split('?').Last());

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Call for hue-scene with id: {0}", parameters["id"]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid call!");
                    Console.ResetColor();

                    p.WriteFailure();
                    return;
                }

                p.OutputStream.Write("success");

            }
            catch (Exception ex)
            {
                p.WriteFailure();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }


        public override void HandlePostRequest(HttpProcessor p, StreamReader inputData)
        {
            throw new NotImplementedException();
        }


        #endregion Services

        #region Internal services
        
        

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
