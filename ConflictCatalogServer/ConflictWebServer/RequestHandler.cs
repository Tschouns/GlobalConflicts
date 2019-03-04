using DataRepository.DbConnection;
using DataRepository.Repository;
using Microsoft.AspNetCore.Http;
using Services.ConflictJson;
using Services.Parser;
using System;
using System.Threading.Tasks;

namespace ConflictWebServer
{
    public static class RequestHandler
    {
        private static readonly Lazy<IRetrieveConflictJson> lazyRetrieveConflictJson = new Lazy<IRetrieveConflictJson>(CreateRetrieveConflictJson);

        public static Task HandleRequests(HttpContext context)
        {
            var jsonString = lazyRetrieveConflictJson.Value.RetrieveConflictJsonString();

            return context.Response.WriteAsync(jsonString);
        }

        private static IRetrieveConflictJson CreateRetrieveConflictJson()
        {
            var dbConnectionProvider = new SingletonSqliteConnectionProvider(Config.ConnectionString);
            return new RetrieveConflictJsonService(
                new ImportedConflictRepository(dbConnectionProvider),
                new NationRepository(dbConnectionProvider),
                new ParseImportedConflictSummaryService());
        }
    }
}
