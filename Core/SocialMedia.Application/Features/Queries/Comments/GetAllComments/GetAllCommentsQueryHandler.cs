using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Comments.GetAllComments
{
    public class GetAllCommentsQueryHandler(ICommentService commentService) : IRequestHandler<GetAllCommentsQueryRequest, GetAllCommentsQueryResponse>
    {
        public async Task<GetAllCommentsQueryResponse> Handle(GetAllCommentsQueryRequest request, CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await commentService.GetAllCommentsAsync();
            return new()
            {
                Comments = comments,
                Count = comments.Count
            };

        }
    }
}
