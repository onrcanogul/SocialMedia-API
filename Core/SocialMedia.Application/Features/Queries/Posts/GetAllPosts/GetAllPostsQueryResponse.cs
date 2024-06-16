using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryResponse
    {
        public List<PostDto> Posts { get; set; }
        public int Count { get; set; }
    }
}