using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Posts.DeletePost
{
    public class DeletePostCommandHandler(IPostService postService) : IRequestHandler<DeletePostCommandRequest, DeletePostCommandResponse>
    {
        public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await postService.DeletePostAsync(request.Id);


            return new()
            {
                Result = result
            };

        }
    }
}
