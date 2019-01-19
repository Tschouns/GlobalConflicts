using Base.RuntimeChecks;
using Logging;

namespace ConflictCatalogDataImport
{
    public class ConflictCatalogProcessor
    {
        public void ProcessCatalog(ConflictCatalogProcessorArguments arguments)
        {
            Argument.AssertIsNotNull(arguments, nameof(arguments));

            Logger.Log.Info($"Starting to process {arguments.FileName}...");
        }
    }
}
