using SocialMedia.Application.Dtos;
using SocialMedia.Application.Dtos.Post;


namespace SocialMedia.Application.Abstractions.Services
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(CreatePostDto createPostDto);
        Task<List<PostDto>> GetAllPostsAsync();
        Task<List<PostDto>> GetPostsByUserAsync(string userId);
        Task<PostDto> GetPostByIdAsync(string id);
        Task<bool> DeletePostAsync(string id);
        Task UpdatePostAsync(UpdatePostDto updatePostDto);
    }
}
