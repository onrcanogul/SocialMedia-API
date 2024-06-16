using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryHandler(IPostService postService) : IRequestHandler<GetAllPostsQueryRequest, GetAllPostsQueryResponse>
    {
        public async Task<GetAllPostsQueryResponse> Handle(GetAllPostsQueryRequest request, CancellationToken cancellationToken)
        {
            List<PostDto> posts = await postService.GetAllPostsAsync();

            return new()
            {
                Posts = posts
            };

        }
    }
}
