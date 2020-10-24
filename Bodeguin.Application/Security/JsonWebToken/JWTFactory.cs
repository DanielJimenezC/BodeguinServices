using Bodeguin.Application.Communication.Request;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bodeguin.Application.Security.JsonWebToken
{
    public class JWTFactory : IJWTFactory
    {
        private readonly JwtOptions jwtOptions;

        public JWTFactory(IOptions<JwtOptions> options)
        {
            jwtOptions = options.Value;
        }

        public async Task<string> GetJWT(string loginRequest)
        {
            var claimsIndentity = GenerateClaims(loginRequest);
            return await GenerateToken(claimsIndentity);
        }

        private Claim[] GenerateClaims(string loginRequest)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, loginRequest)
            };
            return claims;
        }

        private async Task<string> GenerateToken(Claim[] claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);
            var token = new SecurityTokenDescriptor
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var descriptor = tokenHandler.CreateToken(token);
            return tokenHandler.WriteToken(descriptor);
        }
    }
}
