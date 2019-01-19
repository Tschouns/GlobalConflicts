
namespace DataRepository
{
    public class ImportedConflictModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommonName { get; set; }

        public int NumberActors { get; set; }
        public int MilFatalities { get; set; }
        public int TotalFatalities { get; set; }

        public int StartYear { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndYear { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }
    }
}
