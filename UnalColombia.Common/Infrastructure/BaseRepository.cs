using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UnalColombia.Common.Infrastructure
{
    public abstract class BaseRepository<TEntity, TDbContext> : IRepositoryAsync<TEntity> where TEntity : class 
        where TDbContext : DbContext
    {
        protected TDbContext _db;
        protected DbSet<TEntity> _model;

        public BaseRepository(TDbContext context)
        {
            _db = context;
            _model = _db.Set<TEntity>();
        }

        public async Task<bool> Add(IEnumerable<TEntity> entities)
        {
            _model.AddRange(entities);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            _model.AddRange(entities);
        }

        public async Task AddAsync(TEntity entity)
        {
            _db.Add(entity);
        }

        public async Task<bool> Update(TEntity entity)
        {
            if (entity == null) return false;
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
        public async Task<bool> Delete(object id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity == null) return false;
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity != null) 
                _db.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return _model.Where(filter);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _model.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void StartOwnTransactionWithinContext(Action dataBaseOperations)
        {
            using var dbContextTransaction = _db.Database.BeginTransaction();
            try
            {
                dataBaseOperations();
                _db.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception)
            {
                dbContextTransaction.Rollback();
                throw;
            }
        }

       
    }
}
