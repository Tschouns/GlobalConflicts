using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using DataRepository.DataAccess;
using Logging;

namespace ConflictCatalogDataImport.Services
{
    public class ImportConflictCatalogFile : IImportConflictCatalogFile
    {
        public void Import(string fileName, IImportedConflictDataAccess targetRepository)
        {
            //Argument.AssertIsNotNull(targetRepository, nameof(targetRepository));

            IEnumerable<ImportedConflictRow> importedConflicts = new ImportedConflictRow[0];

            Logger.Log.Info($"Reading CSV file '{fileName}'...");
            using (var csvReader = new CsvReader(new StreamReader(fileName)))
            {
                csvReader.Configuration.HasHeaderRecord = true;
                csvReader.Configuration.Delimiter = ";";
                importedConflicts = csvReader.GetRecords<ImportedConflictRow>().ToList();

                Logger.Log.Info($"{importedConflicts.Count()} records read.");
            }

            foreach (var row in importedConflicts)
            {
                Logger.Log.Info("Saving conflict " + row.Name + "...");

                targetRepository.Insert(new ImportedConflictModel()
                    {
                        Name = row.Name,
                        CommonName = row.CommonName,

                        NumberOfActors = row.NumberActors,
                        MilFatalities = row.MilFatalities,
                        TotalFatalities = row.TotalFatalities,

                        StartYear = row.StartYear,
                        StartMonth = row.StartMonth,
                        StartDay = row.StartDay,

                        EndYear = row.EndYear,
                        EndMonth = row.EndMonth,
                        EndDay = row.EndDay,
                    });
            }
        }
    }
}
