namespace StudentViolationWeb.Model
{
    public class RecordViolationModel
    {
        public string StudentNo { get; set; } = string.Empty;
        public int ViolationType { get; set; }
        public string Details { get; set; }
        public string Severity { get; set; }
        public string GuardId { get; set; }

    }
    public class GetSummaryModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

