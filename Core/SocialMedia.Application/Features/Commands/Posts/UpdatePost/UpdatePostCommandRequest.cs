using MediatR;

namespace SocialMedia.Application.Features.Commands.Posts.UpdatePost
{
    public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
    {
        public string Title { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}