using SocialMedia.Application.Dtos;
using SocialMedia.Application.Dtos.LikeDislike;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface ILikeDislikeService
    {
        Task Like(string postId, string userId);

        Task Dislike(string postId, string userId);

        Task<UsersLikeDto> GetUsersLikes(string userId);

        Task<LikeResponseDto> GetLikes(string postId);
        Task<DislikeResponseDto> GetDislikes(string postId);
    }
}
