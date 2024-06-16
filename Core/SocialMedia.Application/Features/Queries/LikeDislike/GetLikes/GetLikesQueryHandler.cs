using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Dtos.LikeDislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.LikeDislike.GetLikes
{
    public class GetLikesQueryHandler(ILikeDislikeService service) : IRequestHandler<GetLikesQueryRequest, GetLikesQueryResponse>
    {
        public async Task<GetLikesQueryResponse> Handle(GetLikesQueryRequest request, CancellationToken cancellationToken)
        {
            LikeDto likeDto = await service.GetLikes(request.PostId);

            return new()
            {
                Count = likeDto.Count,
                Users = likeDto.Users,
            };

        }
    }
}
