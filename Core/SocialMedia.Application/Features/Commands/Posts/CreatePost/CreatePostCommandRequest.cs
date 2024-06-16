using MediatR;

namespace SocialMedia.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}