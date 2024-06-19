using MediatR;

namespace SocialMedia.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryRequest : IRequest <GetUserByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}