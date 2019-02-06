
namespace ConflictCatalogImport
{
    class ImportedConflictRow
    {
        public string Name { get; set; }
        public string CommonName { get; set; }

        public string NumberActors { get; set; }
        public string MilFatalities { get; set; }
        public string TotalFatalities { get; set; }

        public string StartYear { get; set; }
        public string StartMonth { get; set; }
        public string StartDay { get; set; }
        public string EndYear { get; set; }
        public string EndMonth { get; set; }
        public string EndDay { get; set; }
    }
}
