using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;

namespace SocialMedia.Persistance.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(SocialMediaDbContext context) : base(context)
        {
        }
    }
}
