using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentsByPost
{
    public class GetCommentsByPostQueryResponse
    {
        public List<CommentDto> Comments { get; set; }
        public int Count { get; set; }
    }
}