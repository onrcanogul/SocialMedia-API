using MediatR;

namespace SocialMedia.Application.Features.Queries.Posts.GetPostById
{
    public class GetPostByIdQueryRequest : IRequest<GetPostByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}