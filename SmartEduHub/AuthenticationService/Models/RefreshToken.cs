using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Models
{
    public class RefreshToken
    {
            [Key]
            public int Id { get; set; }

            public string UserId { get; set; } = string.Empty;  // Username ya UserId (string rakha hai aapne code mein)

            public string Token { get; set; } = string.Empty;

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime ExpiresAt { get; set; }

            public bool IsRevoked { get; set; } = false;

            public DateTime? RevokedAt { get; set; }
        
    }
}
