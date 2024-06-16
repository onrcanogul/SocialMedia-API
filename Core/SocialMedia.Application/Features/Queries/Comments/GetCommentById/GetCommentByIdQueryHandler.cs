using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Comments.GetCommentById
{
    public class GetCommentByIdQueryHandler(ICommentService commentService) : IRequestHandler<GetCommentByIdQueryRequest, GetCommentByIdQueryResponse>
    {
        public async Task<GetCommentByIdQueryResponse> Handle(GetCommentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            CommentDto comment =  await commentService.GetByIdAsync(request.Id);
            return new()
            {
                Comment = comment
            };
        }
    }
}
