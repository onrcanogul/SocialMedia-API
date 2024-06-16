using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentsByPost
{
    public class GetCommentsByPostQueryHandler(ICommentService commentService) : IRequestHandler<GetCommentsByPostQueryRequest, GetCommentsByPostQueryResponse>
    {
        public async Task<GetCommentsByPostQueryResponse> Handle(GetCommentsByPostQueryRequest request, CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await commentService.GetCommentsByPostAsync(request.PostId);

            return new()
            {
                Comments = comments,
                Count = comments.Count()
            };
        }
    }
}
