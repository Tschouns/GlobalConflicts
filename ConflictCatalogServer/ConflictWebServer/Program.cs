using Logging;
using Logging.Loggers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace ConflictWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.SetLogger(new ConsoleLogger());

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
