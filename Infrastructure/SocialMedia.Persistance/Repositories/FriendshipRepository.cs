using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;

namespace SocialMedia.Persistance.Repositories
{
    public class FriendshipRepository : Repository<Friendship>, IFriendshipRepository
    {
        public FriendshipRepository(SocialMediaDbContext context) : base(context)
        {
        }
    }
}
