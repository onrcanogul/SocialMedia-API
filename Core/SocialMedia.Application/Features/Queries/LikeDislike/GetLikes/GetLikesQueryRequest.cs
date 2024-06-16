using MediatR;

namespace SocialMedia.Application.Features.Queries.LikeDislike.GetLikes
{
    public class GetLikesQueryRequest : IRequest<GetLikesQueryResponse>
    {
        public string PostId { get; set; }
    }
}