using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.UnitOfWork;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Dtos.LikeDislike;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class LikeDislikeService(ILikeRepository likeRepository, IDislikeRepository dislikeRepository, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper) : ILikeDislikeService
    {
        public async Task Dislike(string postId, string userId)
        {
            bool likeResult = await likeRepository.Table.AnyAsync(x => x.PostId == Guid.Parse(postId) && x.UserId == userId);
            Dislike? dislikeResult = await dislikeRepository.Table.FirstOrDefaultAsync(x => x.PostId == Guid.Parse(postId) && x.UserId == userId);
            if (!likeResult && dislikeResult == null)
            {
                Dislike dislike = new Dislike()
                {
                    CreatedDate = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    PostId = Guid.Parse(postId),
                    UserId = userId
                };

                await dislikeRepository.AddAsync(dislike);
                
            }
            else if(!likeResult && dislikeResult != null)      
                dislikeRepository.Delete(dislikeResult);
            
            else
                throw new Exception("You cant like and dislike at the same time");
            await unitOfWork.CommitAsync();
        }

        public async Task<DislikeResponseDto> GetDislikes(string postId)
        {
            List<AppUser> users = await dislikeRepository.Table.Include(x => x.User).Where(x => x.PostId == Guid.Parse(postId)).Select(x => x.User).ToListAsync();

            List<UserDto> usersDto = mapper.Map<List<UserDto>>(users);

            return new()
            {
                Count = users.Count,
                Users = usersDto
            };
        }

        public async Task<LikeResponseDto> GetLikes(string postId)
        {
            List<AppUser> users = await likeRepository.Table.Include(x => x.User).Where(x => x.PostId == Guid.Parse(postId)).Select(x => x.User).ToListAsync();

            List<UserDto> usersDto = mapper.Map<List<UserDto>>(users);
            return new()
            {
                Count = users.Count,
                Users = usersDto
            };
            
        }

        public async Task<UsersLikeDto> GetUsersLikes(string userId)
        {
            List<Post> posts = await likeRepository.Table.Include(x => x.Post).Where(x => x.UserId == userId).Select(x => x.Post).ToListAsync();

            List<PostDto> postsDto = mapper.Map<List<PostDto>>(posts);


            return new()
            {
                Count = posts.Count,
                Posts = postsDto
            };
        }

        public async Task Like(string postId, string userId)
        {
            Like? likeResult = await likeRepository.Table.FirstOrDefaultAsync(x => x.PostId == Guid.Parse(postId) && x.UserId == userId);
            bool dislikeResult = await dislikeRepository.Table.AnyAsync(x => x.PostId == Guid.Parse(postId) && x.UserId == userId);
            
            if (!dislikeResult && likeResult == null)
            {
                Like like = new()
                {
                    Id = Guid.NewGuid(),
                    PostId = Guid.Parse(postId),
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                };
                await likeRepository.AddAsync(like);
            }
            else if (!dislikeResult && likeResult != null)      
                likeRepository.Delete(likeResult); 
            else
                throw new Exception("you can not like and dislike at the same time");
            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
