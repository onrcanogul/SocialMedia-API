using MediatR;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentsByUser
{
    public class GetCommentsByUserQueryRequest : IRequest<GetCommentsByUserQueryResponse>
    {
        public string Id { get; set; }
    }
}