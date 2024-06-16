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
        public string NameSurname => $"{Name} + {Surname}";
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
        public virtual ICollection<Friendship> Friendships { get; set; } = new List<Friendship>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();
    }
}
