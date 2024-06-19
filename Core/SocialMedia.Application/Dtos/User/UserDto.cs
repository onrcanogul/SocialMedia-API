using SocialMedia.Application.Dtos.LikeDislike;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string NameSurname => $"{Name} + {Surname}";
        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
        public ICollection<CommentDto> Comment { get; set; } = new List<CommentDto>();
        public ICollection<Friendship> Friendships { get; set; } = new List<Friendship>();
        public ICollection<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public ICollection<DislikeDto> Dislikes { get; set; } = new List<DislikeDto>();



    }
}
