using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.Comments.CreateComment;
using SocialMedia.Application.Features.Commands.Comments.DeleteComment;
using SocialMedia.Application.Features.Commands.Comments.UpdateComment;
using SocialMedia.Application.Features.Queries.Comments.GetAllComments;
using SocialMedia.Application.Features.Queries.Comments.GetCommentById;
using SocialMedia.Application.Features.Queries.Comments.GetCommentsByPost;
using SocialMedia.Application.Features.Queries.Comments.GetCommentsByUser;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllComments(GetAllCommentsQueryRequest request)
        {
            GetAllCommentsQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentById(GetCommentByIdQueryRequest request)
        {
            GetCommentByIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("user/{Id}")]
        public async Task<IActionResult> GetCommentsByUser(GetCommentsByUserQueryRequest request)
        {
            GetCommentsByUserQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("post/{Id}")]
        public async Task<IActionResult> GetCommentsByPost(GetCommentsByPostQueryRequest request)
        {
            GetCommentsByPostQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommandRequest request)
        {
            CreateCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommandRequest request)
        {
            UpdateCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteComment(DeleteCommentCommandRequest request)
        {
            DeleteCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
