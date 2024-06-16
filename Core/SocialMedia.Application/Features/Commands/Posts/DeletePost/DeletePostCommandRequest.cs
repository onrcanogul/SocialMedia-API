using MediatR;

namespace SocialMedia.Application.Features.Commands.Posts.DeletePost
{
    public class DeletePostCommandRequest : IRequest<DeletePostCommandResponse>
    {
        public string Id { get; set; }
    }
}