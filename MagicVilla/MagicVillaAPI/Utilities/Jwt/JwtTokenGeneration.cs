using MagicVillaAPI.Models.DAO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVillaAPI.Utilities.Jwt
{
    public class JwtTokenGeneration
    {
        public async Task<string> GenerateToken(LocalUser user, string secretKey)
        {
            var secret = secretKey;
            var tokenhandler = new JwtSecurityTokenHandler();
            var encodesecret = Encoding.ASCII.GetBytes(secret);

            var tokendescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(encodesecret), SecurityAlgorithms.HmacSha256Signature)
            };
            var createdToken = tokenhandler.CreateToken(tokendescription);
            var token = tokenhandler.WriteToken(createdToken);
            return token;
        }
    }
}
