using MediatR;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentById
{
    public class GetCommentByIdQueryRequest : IRequest<GetCommentByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}