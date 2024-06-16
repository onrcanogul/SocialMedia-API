using MediatR;

namespace SocialMedia.Application.Features.Commands.LikeDislike.DislikePost
{
    public class DislikeCommandRequest : IRequest<DislikeCommandResponse>
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
    }
}