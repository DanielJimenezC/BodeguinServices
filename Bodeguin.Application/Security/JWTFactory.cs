using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bodeguin.Application.Security
{
    public class JWTFactory : IJWTFactory
    {
        private readonly JwtOptions jwtOptions;

        public JWTFactory(IOptions<JwtOptions> options)
        {
            jwtOptions = options.Value;
        }

        public async Task<string> GetJWT(LoginRequest loginRequest)
        {
            var claimsIndentity = GenerateClaims(loginRequest);
            return await GenerateToken(claimsIndentity);
        }

        private List<Claim> GenerateClaims(LoginRequest loginRequest)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, loginRequest.Email));
            return claims;
        }

        private async Task<string> GenerateToken(List<Claim> claims)
        {
            var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);
            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddMonths(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
