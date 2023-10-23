using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestGlobal.Application.Contracts.Persistence;
using TestGlobal.Domail.Common;
using TestGlobal.Infrastructure.Persistence;

namespace TestGlobal.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly TestGlobalDbContext _context;

        public RepositoryBase(TestGlobalDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
