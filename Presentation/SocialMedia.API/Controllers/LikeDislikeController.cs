using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.LikeDislike.DislikePost;
using SocialMedia.Application.Features.Commands.Likes.LikePost;
using SocialMedia.Application.Features.Queries.LikeDislike.GetDislikes;
using SocialMedia.Application.Features.Queries.LikeDislike.GetLikes;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeDislikeController(IMediator mediator) : ControllerBase
    {
        [HttpGet("likes")]
        public async Task<IActionResult> GetLikes(GetLikesQueryRequest request)
        {
            GetLikesQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("dislikes")]
        public async Task<IActionResult> GetDislikes(GetDislikesQueryRequest request)
        {
            GetDislikesQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("like")]
        public async Task<IActionResult> Like(LikeCommandRequest request)
        {
            LikeCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("dislikes")]
        public async Task<IActionResult> Dislike(DislikeCommandRequest request)
        {
            DislikeCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
