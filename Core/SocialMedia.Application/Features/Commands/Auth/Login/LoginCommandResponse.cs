using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Commands.Auth.Login
{
    public class LoginCommandResponse
    {
        public TokenDto Token { get; set; }
    }
}