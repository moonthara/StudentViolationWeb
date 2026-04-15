namespace StudentViolationWeb.Model
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        
        public string StudentNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;

        
        public DateTime? DateOfBirth { get; set; }

        
        public string Address { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;

        
        public string? QRCode { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public int ViolationCount { get; set; }

        public string WarningLevel { get; set; } = string.Empty;
    }
}
