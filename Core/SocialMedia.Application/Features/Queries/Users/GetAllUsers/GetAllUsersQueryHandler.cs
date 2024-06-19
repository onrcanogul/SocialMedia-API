using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserService userService) : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
    {
        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<UserDto> users = await userService.GetAllUsers();

            return new()
            {
                Count = users.Count,
                Users = users
            };
        }
    }
}
