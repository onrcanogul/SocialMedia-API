using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string NameSurname => $"{Name} + {Surname}";
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Friendship> Friendships { get; set; } = new List<Friendship>();
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();


    }
}
