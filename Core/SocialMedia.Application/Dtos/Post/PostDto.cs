using SocialMedia.Application.Dtos.LikeDislike;
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
        public string Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<CommentDto>? Comments { get; set; }
        public virtual ICollection<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public virtual ICollection<DislikeDto> Dislikes { get; set; } = new List<DislikeDto>();
        public UserDto User { get; set; }
        public string UserId { get; set; } = null!;
    }
}
