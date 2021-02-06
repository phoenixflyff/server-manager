using server_manager.Utils;
using System;

namespace server_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogMessage(Logger.LogLevel.INFO, "Hello {0}", "World");
        }
    }
}
