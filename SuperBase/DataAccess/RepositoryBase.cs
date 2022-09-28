using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SuperBase.DataAccess
{
    public class RepositoryBase<TEntity,TKey> : IAsyncRepository<TEntity,TKey> where TEntity : EntityBase<TKey>
    {
        protected readonly DbContext DbContext;

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
