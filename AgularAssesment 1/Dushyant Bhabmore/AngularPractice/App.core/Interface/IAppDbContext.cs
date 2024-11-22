using Microsoft.EntityFrameworkCore;


namespace App.core.Interface
{
    public interface IAppDBContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
