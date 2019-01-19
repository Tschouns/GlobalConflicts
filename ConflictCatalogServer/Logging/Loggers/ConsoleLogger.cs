using System;
using Base.RuntimeChecks;

namespace Logging.Loggers
{
    public class ConsoleLogger : ILog
    {
        public void Info(string message)
        {
            WriteLineInColor(message, ConsoleColor.White);
        }

        public void Warning(string message)
        {
            WriteLineInColor(LoggerText.Warning + message, ConsoleColor.Yellow);
        }

        public void Error(string message)
        {
            WriteLineInColor(LoggerText.Error + message, ConsoleColor.Red);
        }

        public void Error(Exception exception)
        {
            Argument.AssertIsNotNull(exception, nameof(exception));

            Error(exception.Message);
        }

        private static void WriteLineInColor(string message, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            // Restore old color.
            Console.ForegroundColor = oldColor;
        }
    }
}
