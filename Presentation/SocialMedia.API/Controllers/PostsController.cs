using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.Posts.CreatePost;
using SocialMedia.Application.Features.Commands.Posts.DeletePost;
using SocialMedia.Application.Features.Commands.Posts.UpdatePost;
using SocialMedia.Application.Features.Queries.Posts.GetAllPosts;
using SocialMedia.Application.Features.Queries.Posts.GetPostById;
using SocialMedia.Application.Features.Queries.Posts.GetPostsByUser;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPosts(GetAllPostsQueryRequest request)
        {
            GetAllPostsQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPostById(GetPostByIdQueryRequest request)
        {
            GetPostByIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetPostByUser(GetPostByUserQueryRequest request)
        {
            GetPostByUserQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostCommandRequest request)
        {
            CreatePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatePost(UpdatePostCommandRequest request)
        {
            UpdatePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePost(DeletePostCommandRequest request)
        {
            DeletePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
