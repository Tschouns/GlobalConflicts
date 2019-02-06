using System;
using ConflictCatalogImport.Services;
using DataRepository.DataAccess;
using Logging;
using Logging.Loggers;

namespace ConflictCatalogImport
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
                    new ImportedConflictDataAccess(new SingletonSqlConnectionProvider(Config.ConnectionString)));

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
