using Microsoft.EntityFrameworkCore;

namespace DAL.RepositoryAsyns
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly AppDbContext _primaryDbContext;
        private readonly AppDbContext _readOnlyDbContext;
        private bool _disposed;

        public DbSet<TEntity> Entities => _primaryDbContext.Set<TEntity>();
        public DbContext DbContext => _primaryDbContext;

        public RepositoryAsync(AppDbContext primaryDbContext, AppDbContext? readOnlyDbContext = null)
        {
            _primaryDbContext = primaryDbContext ?? throw new ArgumentNullException(nameof(primaryDbContext));
            _readOnlyDbContext = readOnlyDbContext ?? primaryDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = await Entities.AddAsync(entity, cancellationToken);
            return entry.Entity;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => Entities.AddRangeAsync(entities, cancellationToken);

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Entities.Update(entity);
            return Task.FromResult(entity);
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Entities.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Entities.Remove(entity);
            return Task.FromResult(entity);
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> AsQueryable()
            => (_readOnlyDbContext ?? _primaryDbContext).Set<TEntity>();

        public IQueryable<TEntity> AsNoTrackingQueryable()
            => AsQueryable().AsNoTracking();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _primaryDbContext.SaveChangesAsync(cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _primaryDbContext?.Dispose();
                    if (!ReferenceEquals(_primaryDbContext, _readOnlyDbContext))
                        _readOnlyDbContext?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
