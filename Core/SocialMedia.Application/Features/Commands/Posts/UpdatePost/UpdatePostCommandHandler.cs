using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Posts.UpdatePost
{
    public class UpdatePostCommandHandler(IPostService postService) : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            await postService.UpdatePostAsync(new()
            {
                Id = request.Id,
                Description = request.Description,
                Title = request.Title
            });


            return new();
        }
    }
}
