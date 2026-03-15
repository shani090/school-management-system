using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Dtos
{
    public class RegisterDto
    {
        public string? Username { get; set; }

        [StringLength(13, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digit.")]
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
    }
}
