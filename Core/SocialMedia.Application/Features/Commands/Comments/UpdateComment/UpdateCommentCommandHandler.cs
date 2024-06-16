using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Comments.UpdateComment
{
    public class UpdateCommentCommandHandler(ICommentService commentService) : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await commentService.UpdateCommentAsync(new()
            {
                Id = request.Id,
                Message = request.Message,
                UserId = request.UserId,
            });


            return new();
        }
    }
}
