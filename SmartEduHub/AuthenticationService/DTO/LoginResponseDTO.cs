namespace AuthenticationService.DTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int CollegeId { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
