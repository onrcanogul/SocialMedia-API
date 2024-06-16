﻿using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class UserService(UserManager<AppUser> userManager) : IUserService
    {
        public async Task CreateAsync(CreateUserDto createUserDto)
        {
            CheckConfirm(createUserDto.Password, createUserDto.ConfirmPassword);
            AppUser user = new()
            {
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                Email = createUserDto.Email,
                UserName = createUserDto.UserName,
            };
            IdentityResult result = await userManager.CreateAsync(user,createUserDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User is not created");
            }
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenEndDate)
        {
            if(user != null) 
            { 
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenEndDate.AddMinutes(15);
                await userManager.UpdateAsync(user);
            }
            else
            throw new Exception("user not found");
        }

        private void CheckConfirm(string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                throw new Exception("Passwords must be matched");
            }
        }
    }
}
