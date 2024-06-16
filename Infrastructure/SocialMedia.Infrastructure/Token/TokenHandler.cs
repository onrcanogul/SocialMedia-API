using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialMedia.Infrastructure.Token
{
    public class TokenHandler(IConfiguration configuration) : ITokenHandler
    {
        public TokenDto CreateAccessToken(AppUser user)
        {
            TokenDto token = new();

            //symmetric sec key
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            //signincredential
            SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(15);

            JwtSecurityToken securityToken = new(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                notBefore: DateTime.UtcNow,
                expires: token.Expiration,
                signingCredentials: signingCredentials,
                claims: new List<Claim>() { }
                );

            JwtSecurityTokenHandler handler = new();

            token.AccessToken = handler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();


            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
