using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Likes.LikePost
{
    public class LikeCommandHandler(ILikeDislikeService service) : IRequestHandler<LikeCommandRequest, LikeCommandResponse>
    {
        public async Task<LikeCommandResponse> Handle(LikeCommandRequest request, CancellationToken cancellationToken)
        {
            await service.Like(request.PostId,request.UserId);

            return new();
        }
    }
}
