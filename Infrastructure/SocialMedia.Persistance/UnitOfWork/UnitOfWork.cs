using SocialMedia.Application.Abstractions.UnitOfWork;
using SocialMedia.Persistance.Contexts;

namespace SocialMedia.Persistance.UnitOfWork
{
    public class UnitOfWork(SocialMediaDbContext context) : IUnitOfWork
    {
        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
