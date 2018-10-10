using SmartHttpServer;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Rca.HueHookServer
{
    class Program
    {
        static int Main(string[] args)
        {
            //Default-Port (8008 HTTP-Alternativ)
            const int port = 8008;

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
            Console.WriteLine("{0} v{1}", versionInfo.ProductName, versionInfo.ProductVersion);
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

            #region Init hue client
            if (args.Length != 2)
            {
                Console.WriteLine("Need 2 start parameters, described below:");
                Console.WriteLine("parameter 1: IP of the hue-bridge");
                Console.WriteLine("parameter 2: authorized user-id");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Program is closing...");
                Console.ReadKey();
                return -1;

            }

            IPAddress bridgeIp = null;

            if (IPAddress.TryParse(args[0], out bridgeIp))
            {
                Console.WriteLine("Connect hue bridge at: {0}", bridgeIp);
                m_HueClient.ConnectBridge(bridgeIp, args[1]);
                Thread.Sleep(2500);
            }
            else
            {
                Console.WriteLine("Invalid parameter for ip."); Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Program is closing...");
                Console.ReadKey();
                return -1;
            }
            #endregion


            #region init server
            Console.WriteLine("Start local HTTP server.");

            IPAddress[] ipv4Addresses = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            var ip = IPAddress.Parse("127.0.0.1");


            if (ipv4Addresses.Count() == 0)
            {
                Console.WriteLine("No valid network adapters found.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Program is closing...");
                Console.ReadKey();
                return -1;
            }
            else if (ipv4Addresses.Length == 1)
            {
                ip = ipv4Addresses[0];
            }
            else
            {
                Console.WriteLine("Found more than one network adapters:");
                for (int i = 0; i < ipv4Addresses.Length; i++)
                    Console.WriteLine(" [{0}] {1}", i + 1, ipv4Addresses[i]);
                Console.WriteLine();
                Console.Write("Which adapter would like to use? ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                try
                {
                    ip = ipv4Addresses[Int32.Parse(key.KeyChar.ToString()) - 1];
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong input ({0}), Program is closing...", key.KeyChar);
                    Console.ReadKey();
                    return -1;
                }
            }
            Console.WriteLine();

            Console.Write("HueHookServer is runing under: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("http://{0}:{1}/", ip, port);
            Console.ResetColor();
            for (int i = 0; i < 70; i++)
                Console.Write("-");
            Console.WriteLine();
            Console.WriteLine();
            #endregion


            HttpServer httpServer = new HookReceiver(ip, port);

            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();

            return 0;
        }

    }
}
