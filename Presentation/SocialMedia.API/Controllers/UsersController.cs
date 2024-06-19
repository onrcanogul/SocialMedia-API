using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.Users.CreateUser;
using SocialMedia.Application.Features.Queries.Users.GetAllUsers;
using SocialMedia.Application.Features.Queries.Users.GetUserById;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            GetAllUsersQueryResponse response = await mediator.Send(new GetAllUsersQueryRequest());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute]GetUserByIdQueryRequest request)
        {
            GetUserByIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
