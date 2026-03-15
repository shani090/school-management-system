using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CommonLibrary
{
    public interface ICollegeContextAccessor
    {
        string? GetCollegeId();
    }

    public class CollegeContextAccessor : ICollegeContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CollegeContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetCollegeId()
        {
            return _httpContextAccessor.HttpContext?.Request.Headers["X-College-ID"].FirstOrDefault()
                   ?? _httpContextAccessor.HttpContext?.User.FindFirst("CollegeId")?.Value;
        }
    }
}