using System;
using Services;
using DataRepository.DbConnection;
using DataRepository.Repository;
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
                    new ImportedConflictRepository(new SingletonSqliteConnectionProvider(Config.ConnectionString)));

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
