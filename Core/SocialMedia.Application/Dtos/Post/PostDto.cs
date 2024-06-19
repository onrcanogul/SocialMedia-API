using SocialMedia.Application.Dtos.LikeDislike;

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
        public int LikeCount => Likes.Count;
        public int DislikeCount => Dislikes.Count;    
        public UserDto User { get; set; }
        public string UserId { get; set; } = null!;
    }
}
