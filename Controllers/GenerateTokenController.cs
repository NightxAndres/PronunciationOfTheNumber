using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PronunciationOfTheNumber.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PronunciationOfTheNumber.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class GenerateTokenController : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult Login([FromBody] AccessData userdata)
        {
            if (userdata.username == "Andres Jaramillo" && userdata.password == "technicaltestinalambria")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "user_id"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PruebaRealizadaPorWilliamAndresJaramilloBarbosa"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "your_issuer",
                    audience: "your_audience",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized(new { Message = "El usuario o la contraseña son incorrectas" });

        }
    }

}

