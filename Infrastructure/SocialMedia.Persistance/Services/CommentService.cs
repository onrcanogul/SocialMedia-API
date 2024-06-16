using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.UnitOfWork;
using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class CommentService(ICommentRepository repository, IUnitOfWork unitOfWork ,IMapper mapper) : ICommentService
    {
        public async Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            Comment comment = mapper.Map<Comment>(createCommentDto);
            bool result = await repository.AddAsync(comment);
            await unitOfWork.CommitAsync();
            return result;
        }

        public async Task<bool> DeleteCommentAsync(string id)
        {
            bool result = await repository.DeleteAsync(id);
            await unitOfWork.CommitAsync();
            return result;
        }

        public async Task<List<CommentDto>> GetAllCommentsAsync()
        {
            List<Comment> comments = await GetCommentQuery.ToListAsync();
            return mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetByIdAsync(string id)
        {
            Comment? comment = await GetCommentQuery.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if(comment != null)
                return mapper.Map<CommentDto>(comment);

            throw new Exception("comment is not found");
            
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            Comment? comment = await repository.GetByIdAsync(updateCommentDto.Id);
            if(comment != null)
            {
                comment.Message = updateCommentDto.Message;
                comment.UpdatedDate = DateTime.UtcNow;
            } else
                throw new Exception("comment is not found");
        }

        public async Task<List<CommentDto>> GetCommentsByUserAsync(string userId)
        {
            List<Comment> comments = await GetCommentQuery
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<List<CommentDto>> GetCommentsByPostAsync(string postId)
        {
            List<Comment> comments = await GetCommentQuery
                .Where(x => x.PostId == Guid.Parse(postId))
                .ToListAsync();
            return mapper.Map<List<CommentDto>>(comments);
        }

        public IQueryable<Comment> GetCommentQuery => repository.Table
                .Include(x => x.User)
                .Include(x => x.Post);
    }
}
