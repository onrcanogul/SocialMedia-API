using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.LikeDislike.GetLikes
{
    public class GetLikesQueryResponse
    {
        public List<UserDto> Users { get; set; }
        public int Count { get; set; }
    }
}