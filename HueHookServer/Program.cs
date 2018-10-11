using Rca.HueHook;
using SmartHttpServer;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Rca.HueHookServer
{
    public class Program
    {
        public static HueHookSettings Settings;

        static int Main(string[] args)
        {
            //Default-Port (8008 HTTP-Alternativ)


            const string SETTINGS_PATH = "HueHookSettings.xml";

            Hue m_HueClient = new Hue();

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
                return -1;
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

            
            #region init server
            Console.WriteLine("Start local HTTP server");

            IPAddress[] ipv4Addresses = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            

            if (ipv4Addresses.Count() == 0)
            {
                Console.WriteLine("No valid network adapters found.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Program is closing...");
                Console.ReadKey();
                return -1;
            }
            else if (ipv4Addresses.Any(x => IPAddress.Equals(x, Settings.LocalServerIp))) 
            {
                Console.WriteLine();

                Console.Write("HueHookServer is runing under: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("http://{0}:{1}/", Settings.LocalServerIp, Settings.LocalServerPort);
                Console.ResetColor();
                for (int i = 0; i < 70; i++)
                    Console.Write("-");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No network adapter with ip " + Settings.LocalServerIp + " found.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Program is closing...");
                Console.ReadKey();
                return -1;
            }
            
            #endregion


            HttpServer httpServer = new HookReceiver(Settings.LocalServerIp, Settings.LocalServerPort);

            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();

            return 0;
        }

    }
}
