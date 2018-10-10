using Q42.HueApi;
using SmartHttpServer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                var remoteIp = getRemoteIp(p);
                Console.WriteLine("remote endpoint IP: " + remoteIp);

                if (!Whitelist.IsWhitelisted(remoteIp))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Access denied, remote IP not allowed!");
                    Console.ResetColor();

                    return;
                }

                if (p.HttpUrl.StartsWith("/favicon.ico")) //many browsers ask for favicon.ico
                {
                    p.WriteFailure();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("/favicon.ico");
                    Console.ResetColor();
                    Console.WriteLine("HTTP/1.0 404 File not found");

                    return;
                }
                else if (p.HttpUrl.StartsWith("/light.hue"))
                {
                    //parsing GET parameters
                    var parameters = HttpUtility.ParseQueryString(p.HttpUrl.Split('?').Last());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("/light.hue");
                    Console.ResetColor();

                    var cmd = parameters.ToLightCommand();

                    var res = Hue.Client.SendCommandAsync(cmd, new List<string>() { parameters["id"] });
                }
                else if (p.HttpUrl.StartsWith("/group.hue"))
                {
                    //parsing GET parameters
                    var parameters = HttpUtility.ParseQueryString(p.HttpUrl.Split('?').Last());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("/group.hue");
                    Console.ResetColor();

                    var cmd = parameters.ToLightCommand();

                    Hue.Client.SendGroupCommandAsync(cmd, parameters["id"]);
                }
                else if (p.HttpUrl.StartsWith("/scene.hue"))
                {
                    //parsing GET parameters
                    var parameters = HttpUtility.ParseQueryString(p.HttpUrl.Split('?').Last());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("/scene.hue");
                    Console.ResetColor();


                    Hue.Client.RecallSceneAsync(parameters["id"]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid call: {0}", p.HttpUrl);
                    Console.ResetColor();

                    p.OutputStream.Write("failure");
                    p.WriteFailure();
                    return;
                }

                p.WriteSuccess();
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
        
        IPAddress getRemoteIp(HttpProcessor p)
        {
            if (p.Socket.Client.RemoteEndPoint.GetType() == typeof(IPEndPoint))
                return ((IPEndPoint)p.Socket.Client.RemoteEndPoint).Address;
            else
                return null;
        }
        
        #endregion Internal services

        #region Events


        #endregion Events
    }

    public static class NameValueCollectionExtensions
    {
        public static LightCommand ToLightCommand(this NameValueCollection parameters)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Id:               {0}", parameters["id"]);

            var cmd = new LightCommand()
            {
                Effect = Effect.None
            };

            if (parameters.AllKeys.Contains("on"))
            {
                cmd.On = bool.Parse(parameters["on"]);
                Console.WriteLine("On:               {0}", cmd.On);
            }
            if (parameters.AllKeys.Contains("sat"))
            {
                cmd.Saturation = int.Parse(parameters["sat"]);
                Console.WriteLine("Saturation:       {0}", cmd.Saturation);
            }
            if (parameters.AllKeys.Contains("hue"))
            {
                cmd.Hue = int.Parse(parameters["hue"]);
                Console.WriteLine("Hue:              {0}", cmd.Hue);
            }
            if (parameters.AllKeys.Contains("bri"))
            {
                cmd.Brightness = byte.Parse(parameters["bri"]);
                Console.WriteLine("Brightness:       {0}", cmd.Brightness);
            }
            if (parameters.AllKeys.Contains("ct"))
            {
                cmd.ColorTemperature = int.Parse(parameters["ct"]);
                Console.WriteLine("ColorTemperature: {0}", cmd.ColorTemperature);
            }

            Console.ResetColor();

            return cmd;
        }
    }
}
