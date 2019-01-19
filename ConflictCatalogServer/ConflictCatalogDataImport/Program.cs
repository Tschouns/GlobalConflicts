using Logging;
using Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictCatalogDataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.SetLogger(new ConsoleLogger());

            var arguments = new ConflictCatalogProcessorArguments();

            var processor = new ConflictCatalogProcessor();
            processor.ProcessCatalog(arguments);

            Console.ReadKey();
        }
    }
}
