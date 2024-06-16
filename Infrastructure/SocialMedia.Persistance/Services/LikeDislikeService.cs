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
            bool result = likeRepository.Table.Any(x => x.PostId == Guid.Parse(postId) && x.UserId == userId);
            if (!result)
            {
                Dislike dislike = new Dislike()
                {
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    PostId = Guid.Parse(postId),
                    UserId = userId
                };

                await dislikeRepository.AddAsync(dislike);
                await unitOfWork.CommitAsync();
            }
            else
                throw new Exception("You cant like and dislike at the same time");
        }

        public async Task<DislikeDto> GetDislikes(string postId)
        {
            List<AppUser> users = await dislikeRepository.Table.Include(x => x.User).Where(x => x.PostId == Guid.Parse(postId)).Select(x => x.User).ToListAsync();

            List<UserDto> usersDto = mapper.Map<List<UserDto>>(users);

            return new()
            {
                Count = users.Count,
                Users = usersDto
            };
        }

        public async Task<LikeDto> GetLikes(string postId)
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
            bool result = dislikeRepository.Table.Any(x => x.PostId == Guid.Parse(postId) && x.UserId == userId);
            if (!result)
            {
                Like like = new()
                {
                    PostId = Guid.Parse(postId),
                    UserId = userId
                };
                await likeRepository.AddAsync(like);
                await unitOfWork.CommitAsync();
            }
            else
                throw new Exception("You cant like and dislike at the same time");
        }
    }
}
