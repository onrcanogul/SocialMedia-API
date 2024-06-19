using SocialMedia.Domain.Entities.Base;

namespace SocialMedia.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Comment>? Comments { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; } = null!;

        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();


    }
}
