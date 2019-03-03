using DataRepository.DbConnection;
using DataRepository.Repository;
using Logging;
using Logging.Loggers;
using Services.Parser;
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
                var connectionProvider = new SingletonSqliteConnectionProvider(Config.ConnectionString);
                var processor = new ImportedConflictProcessor(
                    new NationRepository(connectionProvider),
                    new ImportedConflictRepository(connectionProvider),
                    new ParseImportedConflictSummaryService());

                processor.Process();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }

            Console.ReadKey();
        }
    }
}
