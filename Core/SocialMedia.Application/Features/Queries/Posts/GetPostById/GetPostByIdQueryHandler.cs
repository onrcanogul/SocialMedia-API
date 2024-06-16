using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Posts.GetPostById
{
    public class GetPostByIdQueryHandler(IPostService postService) : IRequestHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
    {
        public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQueryRequest request, CancellationToken cancellationToken)
        {
            PostDto post = await postService.GetPostByIdAsync(request.Id);
            return new()
            {
                Post = post,
            };
        }
    }
}
