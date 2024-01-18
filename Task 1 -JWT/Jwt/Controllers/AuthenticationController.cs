using Jwt.Models;
using Jwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Data data = new Data();
        private readonly IConfiguration _configuration;
        private readonly IUserData _userData;

        public AuthController(IConfiguration configuration, IUserData userData)
        {
            _configuration = configuration;
            _userData = userData;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMyName()
        {
            return Ok(_userData.GetMyName());
        }

        [HttpPost("register")]
        public ActionResult<Data> Register(UserData request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            data.Username = request.Username;
            data.PasswordHash = passwordHash;

            return Ok(data);
        }

        [HttpPost("login")]
        public ActionResult<Data> Login(UserData request)
        {
            if (data.Username != request.Username)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, data.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(data);

            return Ok(token);
        }

        private string CreateToken(Data data)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, data.Username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}