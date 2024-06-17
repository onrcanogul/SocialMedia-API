using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos.LikeDislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.LikeDislike.GetDislikes
{
    public class GetDislikesQueryHandler(ILikeDislikeService service) : IRequestHandler<GetDislikesQueryRequest, GetDislikesQueryResponse>
    {
        public async Task<GetDislikesQueryResponse> Handle(GetDislikesQueryRequest request, CancellationToken cancellationToken)
        {
            DislikeResponseDto dislike = await service.GetDislikes(request.PostId);

            return new()
            {
                Count = dislike.Count,
                Users = dislike.Users
            };
        }
    }
}
