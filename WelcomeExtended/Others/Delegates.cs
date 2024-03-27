using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others
{
    internal class Delegates
    {
        public static ILogger logger = LoggerHelper.GetLogger("Hello");

        public static void Log(string err)
        {
            logger.LogError(err);
        }

        public static void Log2(string err) 
        {
            Console.WriteLine("DELEGATES");
            Console.WriteLine($"{err}");
            Console.WriteLine("DELEGATES");
        }
    }
}
