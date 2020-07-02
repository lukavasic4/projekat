using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Projekat.EfDataAccess;

namespace Projekat.Api.Core
{
    public class JwtManager
    {
        private readonly ProjekatContext _context;
        public JwtManager(ProjekatContext context)
        {
            _context = context;
        }
        public string MakeToken(string username, string password)
        {
            var user = _context.Users.Include(u => u.UserUseCases).FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.UserUseCases.Select(x => x.UseCaseId),
                Indenty = user.Username
            };
            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString(),ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer),
                new Claim("UserId",actor.Id.ToString(),ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor),ClaimValueTypes.String,issuer)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var crendentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken
            (
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(600),
                signingCredentials: crendentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
