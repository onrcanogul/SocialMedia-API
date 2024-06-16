using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentsByUser
{
    public class GetCommentsByUserQueryHandler(ICommentService commentService) : IRequestHandler<GetCommentsByUserQueryRequest, GetCommentsByUserQueryResponse>
    {
        public async Task<GetCommentsByUserQueryResponse> Handle(GetCommentsByUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await commentService.GetCommentsByUserAsync(request.Id);
            return new()
            {
                Comments = comments,
                Count = comments.Count()
            };
        }
    }
}
