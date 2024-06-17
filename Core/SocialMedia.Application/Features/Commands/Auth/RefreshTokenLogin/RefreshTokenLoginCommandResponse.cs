using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Features.Commands.Auth.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public TokenDto Token{ get; set; }
    }
}