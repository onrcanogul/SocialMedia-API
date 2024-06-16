using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Comments.CreateComment
{
    public class CreateCommentCommandHandler(ICommentService commentService) : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await commentService.CreateCommentAsync(new()
            {
                Message = request.Message,
                UserId = request.UserId,
            });

            return new()
            {
                Result = result,
            };
        }
    }
}
