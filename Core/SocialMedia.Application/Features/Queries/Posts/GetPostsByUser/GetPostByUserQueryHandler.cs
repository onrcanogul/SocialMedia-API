using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Posts.GetPostsByUser
{
    public class GetPostByUserQueryHandler(IPostService postService) : IRequestHandler<GetPostByUserQueryRequest, GetPostByUserQueryResponse>
    {
        public async Task<GetPostByUserQueryResponse> Handle(GetPostByUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<PostDto> posts = await postService.GetPostsByUserAsync(request.Id);

            return new()
            {
                Posts = posts,
                Count = posts.Count
            };
        }
    }
}
