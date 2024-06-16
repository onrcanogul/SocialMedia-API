using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler(IPostService postService) : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await postService.CreatePostAsync(new()
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId,

            });

            return new()
            {
                Result = result
            };


        }
    }
}
