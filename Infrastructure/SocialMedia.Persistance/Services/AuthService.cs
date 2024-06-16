using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService) : IAuthService
    {
        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            AppUser? user = await userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
            if (user == null)
            {
                user = await userManager.FindByNameAsync(loginDto.UsernameOrEmail);
                if (user == null)
                    throw new Exception("user is not found");
            }
            SignInResult result =  await signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (result.Succeeded)
            {
                TokenDto token = tokenHandler.CreateAccessToken(user);
                await userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration);

                return token;
            }
            throw new Exception("Invalid login");

        }

        public async Task<TokenDto> RefreshTokenLogin(string refreshToken)
        {
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            if(user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDto token = tokenHandler.CreateAccessToken(user);
                await userService.UpdateRefreshTokenAsync(token.RefreshToken,user, token.Expiration);
                return token;
            }
            throw new Exception("user not found");
        }
    }
}
