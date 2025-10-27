using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        public DbSet<TEntity> Entities { get; }

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Entities = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var entry = Entities.Add(entity);
            return entry.Entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            var entry = Entities.Update(entity);
            return entry.Entity;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
        }

        public TEntity Remove(TEntity entity)
        {
            var entry = Entities.Remove(entity);
            return entry.Entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> AsNoTrackingQueryable()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
