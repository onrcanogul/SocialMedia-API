using SocialMedia.Domain.Entities.Base;

namespace SocialMedia.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
