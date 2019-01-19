using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Base.RuntimeChecks;
using CsvHelper;
using DataRepository;
using Logging;

namespace ConflictCatalogDataImport.Services
{
    public class ImportConflictCatalogFile : IImportConflictCatalogFile
    {
        public void Import(string fileName, IImportedConflictRepository targetRepository)
        {
            //Argument.AssertIsNotNull(targetRepository, nameof(targetRepository));

            IEnumerable<ImportedConflictRow> importedConflicts = new ImportedConflictRow[0];

            Logger.Log.Info($"Reading CSV file '{fileName}'...");
            using (var streamReader = new StreamReader(fileName))
            using (var csvReader = new CsvReader(streamReader))
            {
                csvReader.Configuration.HasHeaderRecord = true;
                csvReader.Configuration.Delimiter = ";";
                importedConflicts = csvReader.GetRecords<ImportedConflictRow>();

                Logger.Log.Info($"{importedConflicts.Count()} records read.");
            }


        }
    }
}
