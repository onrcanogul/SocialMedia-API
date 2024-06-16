using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto createUserDto);

        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenEndDate);
    }
}
