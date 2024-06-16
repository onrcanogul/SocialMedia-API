using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Posts.GetPostsByUser
{
    public class GetPostByUserQueryResponse
    {
        public List<PostDto> Posts { get; set; }
        public int Count { get; set; }
    }
}