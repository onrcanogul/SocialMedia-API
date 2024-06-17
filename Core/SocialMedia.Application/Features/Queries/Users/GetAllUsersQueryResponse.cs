using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Users
{
    public class GetAllUsersQueryResponse
    {
        public List<UserDto> Users{ get; set; }
        public int Count { get; set; }
    }
}