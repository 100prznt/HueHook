using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.HueHook.Util
{
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
                cmd.On = parameters["on"].ToBoolean();
                Console.WriteLine("On:               {0}", cmd.On);
            }
            if (parameters.AllKeys.Contains("sat"))
            {
                int sat = 0;
                if (int.TryParse(parameters["sat"], out sat))
                {
                    cmd.Saturation = sat;
                    Console.WriteLine("Saturation:       {0}", cmd.Saturation);
                }
            }
            if (parameters.AllKeys.Contains("hue"))
            {
                int hue = 0;
                if (int.TryParse(parameters["hue"], out hue))
                {
                    cmd.Hue = hue;
                    Console.WriteLine("Hue:              {0}", cmd.Hue);
                }
            }
            if (parameters.AllKeys.Contains("bri"))
            {
                byte bri = 0;
                if (byte.TryParse(parameters["bri"], out bri))
                {
                    cmd.Brightness = bri;
                    Console.WriteLine("Brightness:       {0}", cmd.Brightness);
                }
            }
            if (parameters.AllKeys.Contains("ct"))
            {
                int ct = 153;
                if (int.TryParse(parameters["ct"], out ct))
                {
                    if (ct >= 153 && ct <= 500)
                    {
                        cmd.ColorTemperature = ct;
                        Console.WriteLine("ColorTemperature: {0}", cmd.ColorTemperature);
                    }
                }
            }

            Console.ResetColor();

            return cmd;
        }
    }
}
