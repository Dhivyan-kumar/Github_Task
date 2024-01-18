using System.Security.Claims;

namespace Jwt.Services
{
    public class UserServices : IUserData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}