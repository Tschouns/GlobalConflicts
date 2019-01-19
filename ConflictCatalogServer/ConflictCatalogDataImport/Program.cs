using ConflictCatalogDataImport.Services;
using DataRepository;
using Logging;
using Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            try
            {
                var arguments = new ConflictCatalogProcessorArguments();
                arguments.FileName = Config.FileName;

                var processor = new ConflictCatalogProcessor(
                    new ImportConflictCatalogFile(),
                    new ImportedConflictRepository());

                processor.ProcessCatalog(arguments);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }

            Console.ReadKey();
        }
    }
}
