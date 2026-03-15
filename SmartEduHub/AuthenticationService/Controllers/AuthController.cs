using AuthenticationService.DTO;
using AuthenticationService.Models;
using AuthenticationService.Services;
using CommonLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly AuthDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int _collegeId;

        public AuthController(AuthDbContext context,IHttpContextAccessor httpContextAccessor,TokenService tokenService,IHttpClientFactory httpClientFactory,IConfiguration configuration,ILogger<AuthController> logger, ICollegeContextAccessor collegeContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;

            Int32.TryParse(collegeContextAccessor.GetCollegeId(), out _collegeId);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var userManagementUrl = _configuration["UserManagementService:BaseUrl"].TrimEnd('/') + "/Validate";

            client.DefaultRequestHeaders.Add("X-College-ID", _collegeId.ToString());

            var response = await client.PostAsJsonAsync(userManagementUrl, dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("Login failed for {Username}: {Error}", dto.Username, errorContent);
                return BadRequest(new { message = "Invalid credentials or server error." });
            }

            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            string jwtToken = result?.token?.ToString();

            if (string.IsNullOrEmpty(jwtToken))
                return Unauthorized("Invalid token received.");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(jwtToken);

            var userId = jsonToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var username = jsonToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var role = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var collegeId = jsonToken.Claims.FirstOrDefault(c => c.Type == "CollegeId")?.Value;
            var email = jsonToken.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Missing user data in token.");

            var newToken = _tokenService.GenerateToken(userId, username, role, collegeId, email);
            var refreshToken = await _tokenService.GenerateRefreshToken(username);

            Response.Cookies.Append("Token", newToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Production mein true rakho
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.Now.AddHours(8)
            });

            return Ok(new { Token = newToken, RefreshToken = refreshToken });
        }


        //[HttpPost("refresh")]
        //public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        //{
        //    var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        //    if (principal == null) return Unauthorized();

        //    var username = principal.Identity?.Name;
        //    var storedToken = await _tokenService.GetRefreshTokenAsync(request.RefreshToken);

        //    if (storedToken == null || storedToken.UserId != username)
        //        return Unauthorized();

        //    var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims, TimeSpan.FromHours(8));
        //    var newRefreshToken = await _tokenService.GenerateRefreshToken(username);

        //    await _tokenService.RevokeRefreshTokenAsync(request.RefreshToken);

        //    return Ok(new { Token = newAccessToken, RefreshToken = newRefreshToken });
        //}

        [HttpGet("secure")]
        [Authorize]
        public IActionResult SecureEndpoint()
        {
            var username = User.Identity?.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var collegeId = User.FindFirst("CollegeId")?.Value;
            var email = User.FindFirst("Email")?.Value;

            return Ok(new
            {
                message = "Secure endpoint accessed",
                username,
                role,
                collegeId,
                email
            });
        }
        
    }
}