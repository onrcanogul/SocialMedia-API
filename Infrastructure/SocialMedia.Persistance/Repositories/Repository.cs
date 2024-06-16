using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Domain.Entities.Base;
using SocialMedia.Persistance.Contexts;
using System.Linq.Expressions;

namespace SocialMedia.Persistance.Repositories
{
    public class Repository<T>(SocialMediaDbContext context) : IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entiryState = await Table.AddAsync(entity);
            return entiryState.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
            EntityEntry entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            T entity = await GetByIdAsync(id);
            return Delete(entity);
        }

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(string id)
        {
            T? entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return entity;
        }

        public void Update(T entity) => Table.Update(entity);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => Table.Where(expression);
    }
}
