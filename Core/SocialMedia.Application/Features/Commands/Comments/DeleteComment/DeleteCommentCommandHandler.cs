using MediatR;
using SocialMedia.Application.Abstractions.Services;

namespace SocialMedia.Application.Features.Commands.Comments.DeleteComment
{
    public class DeleteCommentCommandHandler(ICommentService commentService) : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await commentService.DeleteCommentAsync(request.Id);

            return new()
            {
                Result = result
            };
        }
    }
}
