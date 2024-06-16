using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos
{
    public class PostDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<CommentDto>? Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();
        public AppUser User { get; set; }
        public string UserId { get; set; } = null!;
    }
}
