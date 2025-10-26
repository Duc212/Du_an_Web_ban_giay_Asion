using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace DAL.RepositoryAsyns
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {
        DbContext DbContext { get; }
        DbSet<TEntity> Entities { get; }

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        IQueryable<TEntity> AsQueryable();
        IQueryable<TEntity> AsNoTrackingQueryable();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
