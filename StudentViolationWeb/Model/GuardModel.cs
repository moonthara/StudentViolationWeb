namespace StudentViolationWeb.Model
{
    public class RecordViolationModel
    {
        public int StudentNo { get; set; }
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

