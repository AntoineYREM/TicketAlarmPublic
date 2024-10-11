using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Models;

namespace TicketAlarm.Infrastructure.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        public TokenSettings TokenSettings { get; }

        public TokenGenerator(IOptions<TokenSettings> tokenSettings)
        {
            TokenSettings = tokenSettings.Value;
        }

        public string GenerateToken(string role, string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, username),
                new Claim(ClaimTypes.NameIdentifier, username),
            };

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
