using MediatR;

namespace SocialMedia.Application.Features.Queries.LikeDislike.GetDislikes
{
    public class GetDislikesQueryRequest : IRequest<GetDislikesQueryResponse>
    {
        public string PostId { get; set; }
    }
}