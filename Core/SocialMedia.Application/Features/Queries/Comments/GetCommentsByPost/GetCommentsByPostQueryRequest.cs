using MediatR;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentsByPost
{
    public class GetCommentsByPostQueryRequest : IRequest<GetCommentsByPostQueryResponse>
    {
        public string Id { get; set; }
    }
}