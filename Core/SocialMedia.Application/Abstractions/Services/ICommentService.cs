using SocialMedia.Application.Dtos;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsAsync();
        Task<List<CommentDto>> GetCommentsByUserAsync(string userId);
        Task<List<CommentDto>> GetCommentsByPostAsync(string postId);
        Task<CommentDto> GetByIdAsync(string id);
        Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<bool> DeleteCommentAsync(string id);
        
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
    }
}
