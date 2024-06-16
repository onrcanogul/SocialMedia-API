using MediatR;

namespace SocialMedia.Application.Features.Commands.Likes.LikePost
{
    public class LikeCommandRequest : IRequest<LikeCommandResponse>
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
    }
}