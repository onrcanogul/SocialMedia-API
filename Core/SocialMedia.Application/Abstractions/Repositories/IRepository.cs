using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities.Base;
using System.Linq.Expressions;

namespace SocialMedia.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get ; }
        IQueryable<T> GetAll();
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        bool Delete(T entity);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
