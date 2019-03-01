using Logging;
using Logging.Loggers;
using System;

namespace ConflictAndActorMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.SetLogger(new ConsoleLogger());

            try
            {
                
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }

            Console.ReadKey();
        }
    }
}
