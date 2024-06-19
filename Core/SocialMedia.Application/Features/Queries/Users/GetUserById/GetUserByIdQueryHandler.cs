using MediatR;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler(IUserService userService) : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            UserDto user = await userService.GetUserById(request.Id);

            return new()
            {
                User = user
            };
        }
    }
}
