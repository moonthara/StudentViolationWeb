namespace StudentViolationWeb.Model
{
    public class RegisterModel
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
        public string Address { get; set; } = "";
        public string Number { get; set; } = "";
        public string Role { get; set; } = "";
        public string? StudentNo { get; set; }
        public string? Course { get; set; }
        public string? Year { get; set; }
    }
}
