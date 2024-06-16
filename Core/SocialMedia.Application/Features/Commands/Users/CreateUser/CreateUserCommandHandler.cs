using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await userService.CreateAsync(new() { Email = request.Email, Name = request.Name, Password = request.Password, ConfirmPassword = request.ConfirmPassword, Surname = request.Surname, UserName = request.UserName })

            return new();
        }
    }
}
