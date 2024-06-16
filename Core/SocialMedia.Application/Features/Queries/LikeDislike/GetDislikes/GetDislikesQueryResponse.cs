using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.LikeDislike.GetDislikes
{
    public class GetDislikesQueryResponse
    {
        public List<UserDto> Users { get; set; }
        public int Count { get; set; }
    }
}