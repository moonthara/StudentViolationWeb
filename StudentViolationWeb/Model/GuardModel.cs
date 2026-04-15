namespace StudentViolationWeb.Model
{
    public class RecordViolationModel
    {
        public int StudentNo { get; set; } 
        public int ViolationType { get; set; }
        public string Details { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string GuardId { get; set; } = string.Empty;

    }
    public class GetSummaryModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}


