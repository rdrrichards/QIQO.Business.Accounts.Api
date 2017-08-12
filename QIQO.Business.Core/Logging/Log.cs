using System;

namespace QIQO.Business.Core.Logging
{
    public static class Log
    {
        public static void Info(string message)
        {
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}
