using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementService.Data;
using UserManagementService.Dtos;
using UserManagementService.Interface;
using UserManagementService.Models;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly ILogger<UserController> _logger;

        public UserController(UserDbContext context, ILogger<UserController> logger, IUser user) 
        {
        _user = user;
        _logger = logger;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var result = await _user.Register(registerDto);

                if (result.Message == "PhoneNumber already exists")
                {
                    return Conflict(new { status = "error", message = result.Message });
                }
                if (result.Message == "Email already exists")
                {
                    return StatusCode(500, new { status = "error", message = result.Message });
                }
                if (result.Message == "Password must be at least 6 characters long")
                {
                    return BadRequest(new { status = "error", message = result.Message });
                }
                if (result.Message == "Password must contain at least one special character")
                {
                    return BadRequest(new { status = "error", message = result.Message });
                }

                return Ok(new
                {
                    status = "success",
                    id = result.Id,
                    message = result.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering a user.");
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }
    }
}
