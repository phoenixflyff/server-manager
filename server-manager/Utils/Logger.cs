using System;
using System.Collections.Generic;
using System.Text;

namespace server_manager.Utils
{
    static class Logger
    {
        public enum LogLevel
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }

        public static void LogMessage(LogLevel level, string message, params object?[] args)
        {
            var formattedMessage = String.Format(message, args);
            Logger.LogMessage(level, formattedMessage);
        }

        public static void LogMessage(LogLevel level, string message)
        {
            var outputMessage = String.Format("[{0}] {1}", level, message);
            Console.WriteLine(outputMessage);
        }
    }
}
