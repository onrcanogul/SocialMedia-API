using MediatR;

namespace SocialMedia.Application.Features.Commands.Comments.CreateComment
{
    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}