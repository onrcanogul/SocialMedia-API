using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;

namespace SocialMedia.Persistance.Repositories
{
    public class DislikeRepository : Repository<Dislike>, IDislikeRepository
    {
        public DislikeRepository(SocialMediaDbContext context) : base(context)
        {
        }
    }
}
