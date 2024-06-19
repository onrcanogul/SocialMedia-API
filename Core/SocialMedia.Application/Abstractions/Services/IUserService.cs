using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto createUserDto);

        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenEndDate);

        Task<List<UserDto>> GetAllUsers();

        Task<UserDto> GetUserById(string id);
    }
}
