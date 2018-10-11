using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rca.HueCmd
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
