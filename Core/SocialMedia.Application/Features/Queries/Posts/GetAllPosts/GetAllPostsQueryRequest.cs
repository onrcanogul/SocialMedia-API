using MediatR;

namespace SocialMedia.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryRequest : IRequest<GetAllPostsQueryResponse>
    {
    }
}