using AuthenticationService.Models;
using System.Security.Claims;

namespace AuthenticationService.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string username, string role, string collegeId, string? email);
        Task<string> GenerateRefreshToken(string username);
        string GenerateAccessToken(IEnumerable<Claim> claims, TimeSpan validFor);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        Task<RefreshToken?> GetRefreshTokenAsync(string token);
        Task RevokeRefreshTokenAsync(string token);
        ClaimsPrincipal ValidateToken(string token);
    }
}
