using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentsByUser
{
    public class GetCommentsByUserQueryResponse
    {
        public List<CommentDto> Comments { get; set; }
        public int Count { get; set; }
    }
}