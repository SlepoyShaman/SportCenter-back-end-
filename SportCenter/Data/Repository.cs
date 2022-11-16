using Microsoft.EntityFrameworkCore;
using SportCenter.Models.DataModels;

namespace SportCenter.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
            => _context.Set<TEntity>().Select(e => e);
        public async Task<TEntity> GetByIdAsync<TEntity>(int Id) where TEntity : class, IWithId
            => await _context.Set<TEntity>().FirstAsync(e => e.Id == Id);
        public async Task<TEntity> RemoveByIdAsync<TEntity>(int Id) where TEntity : class, IWithId
        {
            var element = await GetByIdAsync<TEntity>(Id);
            _context.Set<TEntity>().Remove(element);
            await _context.SaveChangesAsync();
            return element;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
