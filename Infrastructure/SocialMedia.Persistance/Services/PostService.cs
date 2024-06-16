using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.UnitOfWork;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Dtos.Post;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class PostService(IPostRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IPostService
    {
        public async Task<bool> CreatePostAsync(CreatePostDto createPostDto)
        {
            Post post = mapper.Map<Post>(createPostDto);
            bool result = await repository.AddAsync(post);
            await unitOfWork.CommitAsync();
            return result;
        }

        public async Task<bool> DeletePostAsync(string id)
        {
            bool result = await repository.DeleteAsync(id);
            await unitOfWork.CommitAsync();
            return result;
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            List<Post> posts = await GetPostQuery.ToListAsync();

            List<PostDto> postDtos = mapper.Map<List<PostDto>>(posts);
            return postDtos;
        }

        public async Task<PostDto> GetPostByIdAsync(string id)
        {
            Post? post = await GetPostQuery.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if(post != null)
            {
                PostDto postDto = mapper.Map<PostDto>(post);
                return postDto;
            }
            throw new Exception("Post not found");
        }

        public async Task UpdatePostAsync(UpdatePostDto updatePostDto)
        {
            Post? post = await repository.GetByIdAsync(updatePostDto.Id);
            if (post != null)
            {
                post.Title = updatePostDto.Title;
                post.Description = updatePostDto.Description;
                await unitOfWork.CommitAsync();
            }
            else throw new Exception("Post not found");
            
        }

        public async Task<List<PostDto>> GetPostsByUserAsync(string userId)
        {
            List<Post> posts = await GetPostQuery
                .Where(x => x.UserId == userId)
                .ToListAsync();
            
            return mapper.Map<List<PostDto>>(posts);
        }

        private IQueryable<Post> GetPostQuery => repository.Table
                .Include(x => x.User)
                .Include(x => x.Comments);
    }
}
