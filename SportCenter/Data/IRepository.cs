using SportCenter.Models.DataModels;

namespace SportCenter.Data
{
    public interface IRepository
    {
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        public Task<TEntity> GetByIdAsync<TEntity>(int Id) where TEntity : class, IWithId;
        public Task<TEntity> RemoveByIdAsync<TEntity>(int Id) where TEntity : class, IWithId;
        public Task AddAsync <TEntity>(TEntity entity) where TEntity : class;
    }
}
