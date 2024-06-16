using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;

namespace SocialMedia.Persistance.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(SocialMediaDbContext context) : base(context)
        {
        }
    }
}
