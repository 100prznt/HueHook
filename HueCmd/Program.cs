﻿using Rca.HueHook;
using Rca.HueHook.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rca.HueCmd
{

    class Program
    {
        public static HueHookSettings Settings;

        static void Main(string[] args)
        {
            const string SETTINGS_PATH = "HueCmdSettings.xml";

            Hue m_HueClient = new Hue();

            bool m_DebugModeActive = false;

            #region Startup

            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var attribute = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                    .Cast<AssemblyDescriptionAttribute>().FirstOrDefault();

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            //Console.WriteLine("{0} v{1}", typeof(Program).Assembly.GetName().Name, typeof(Program).Assembly.GetName().Version);
            Console.WriteLine("{0} v{1}", typeof(Program).Assembly.GetName().Name, versionInfo.ProductVersion);
            Console.ResetColor();
            if (attribute != null)
                Console.WriteLine(attribute.Description);
            Console.WriteLine();
            Console.WriteLine(versionInfo.LegalCopyright);
            for (int i = 0; i < 70; i++)
                Console.Write("-");
            Console.WriteLine();
            Console.WriteLine();

            #endregion

            #region handle args

            //All args start with "-" add to NVC
            var parameters = new NameValueCollection();
            HueObjects hueObject = HueObjects.None;

            foreach (var arg in args)
            {
                if (string.Equals(arg, "-debug", StringComparison.OrdinalIgnoreCase))
                {
                    m_DebugModeActive = true;
                }
                else if (arg.StartsWith("-"))
                {
                    if (arg.EndsWith(".hue"))
                    {
                        var obj = arg.Substring(1, arg.Length - 5);
                        try
                        {
                            hueObject = (HueObjects)Enum.Parse(typeof(HueObjects), obj, true);
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ResetColor();
                            Console.WriteLine();
                            PrintHelp();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Program is closing...");
                            Console.ReadKey();
                        }
                    }
                    var parameter = arg.Split(new string[3] { "-", "=", ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parameter.Length == 2)
                        parameters.Add(parameter[0], parameter[1]);
                }
            }

            if (parameters.Count < 1)
            {
                Console.WriteLine("No parameters found!");
                Console.WriteLine();
                PrintHelp();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Program is closing...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Parameters found:");
                Console.WriteLine();

                foreach (var p in parameters.AllKeys)
                {
                    Console.WriteLine(parameters.)
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            
            //TODO: verify parameters

            #endregion

            #region Init program
            Console.WriteLine("Load settings: {0}", SETTINGS_PATH);
            Console.WriteLine();
            try
            {
                Settings = HueHookSettings.FromFile(SETTINGS_PATH);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.Write("Program is closing...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Settings loaded successfully");
            Console.WriteLine();
            for (int i = 0; i < 70; i++)
                Console.Write("-");
            Console.WriteLine();
            Console.WriteLine();

            #endregion

            #region Init hue client
            Console.WriteLine("Try to connect hue bridge at: {0}", Settings.BridgeIp);
            Console.WriteLine();
            m_HueClient.ConnectBridge(Settings.BridgeIp, Settings.BridgeUsername);
            Thread.Sleep(2500);

            for (int i = 0; i < 70; i++)
                Console.Write("-");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Execute command

            switch (hueObject)
            {
                case HueObjects.Light:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Setup LIGHT");
                    Console.ResetColor();

                    var cmd1 = parameters.ToLightCommand();
                    Hue.Client.SendCommandAsync(cmd1, new List<string> {parameters["id"]});
                    break;
                case HueObjects.Group:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Setup GROUP");
                    Console.ResetColor();

                    var cmd2 = parameters.ToLightCommand();
                    Hue.Client.SendGroupCommandAsync(cmd2, parameters["id"]);
                    break;
                case HueObjects.Scene:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Setup SCENE");
                    Console.ResetColor();

                    Hue.Client.RecallSceneAsync(parameters["id"]);
                    break;
            }
            #endregion

#if DEBUG
            Console.ReadKey();
#endif
        }

        static void PrintHelp()
        {
            Console.WriteLine("Startparameters");
            Console.WriteLine("");
            Console.WriteLine("|Description       |Name | Value     |Light     |Group     |Scene     |");
            Console.WriteLine("|------------------|-----|-----------|----------|----------|----------|");
            Console.WriteLine("|Object*           |     |           |-light.hue|-group.hue|-scene.hue|");
            Console.WriteLine("|ID*               |-id  |0 - 254    |y         |y         |y         |");
            Console.WriteLine("|On state          |-on  |0, 1       |y         |y         |n         |");
            Console.WriteLine("|Hue               |-hue |0 - 65535  |y         |y         |n         |");
            Console.WriteLine("|Saturation        |-sat |0 - 254    |y         |y         |n         |");
            Console.WriteLine("|Brightness        |-bri |0 - 254    |y         |y         |n         |");
            Console.WriteLine("|Color Temperature |-ct  |153 - 500  |y         |y         |n         |");
            Console.WriteLine("");
            Console.WriteLine("*) required parameter - y) parameter allowed - n) parameter not allowed");
            Console.WriteLine("");
            Console.WriteLine("The program must be started with at least the required parameters, marked with *." + 
                "In addition, further allowed parameters (y) can be appended.");
            Console.WriteLine("");
            Console.WriteLine("Example");
            Console.WriteLine("HueCmd.exe -light.hue -id=1 -on=1 -bri=127");
            Console.WriteLine("This means, switch on the light with ID 1 and setup the brightness to a value of 127.");
        }
    }
}
