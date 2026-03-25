namespace StudentViolationWeb.Model
{

    public class Login
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string Role { get; set; } = "";
        public string Token { get; set; } = "";
    }
}
