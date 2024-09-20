using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SchoolNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (userName != "Qayyum" || password != "qayyum")
            {
                return Unauthorized();
            }
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes("74578CB6-DF59-4CF0-AF30-4E343404E2F4"));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var allClaims = new List<Claim>(claims);
            var token = new JwtSecurityToken(
                  issuer: "AbdulQayyum",
                  audience: "my-client-id",
                  claims: allClaims,
                  expires: DateTime.Now.AddHours(1),
                  signingCredentials: credential
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    } }
}
