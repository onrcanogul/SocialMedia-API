using MediatR;

namespace SocialMedia.Application.Features.Queries.Users
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
    }
}