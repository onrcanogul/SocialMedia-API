using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.LikeDislike.DislikePost
{
    public class DislikeCommandHandler(ILikeDislikeService service) : IRequestHandler<DislikeCommandRequest, DislikeCommandResponse>
    {
        public async Task<DislikeCommandResponse> Handle(DislikeCommandRequest request, CancellationToken cancellationToken)
        {
            await service.Dislike(request.PostId, request.UserId);
            return new();
        }
    }
}
