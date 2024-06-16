using MediatR;

namespace SocialMedia.Application.Features.Queries.Posts.GetPostsByUser
{
    public class GetPostByUserQueryRequest : IRequest<GetPostByUserQueryResponse>
    {
        public string Id { get; set; }
    }
}