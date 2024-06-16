using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Comments.GetAllComments
{
    public class GetAllCommentsQueryResponse
    {
        public List<CommentDto>  Comments { get; set; }
        public int Count { get; set; }
    }
}