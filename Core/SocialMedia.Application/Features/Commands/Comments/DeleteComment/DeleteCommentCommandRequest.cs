using MediatR;


namespace SocialMedia.Application.Features.Commands.Comments.DeleteComment
{
    public class DeleteCommentCommandRequest : IRequest<DeleteCommentCommandResponse>
    {
        public string Id { get; set; }
    }
}