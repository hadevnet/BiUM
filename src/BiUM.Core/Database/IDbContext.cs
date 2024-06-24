namespace BiUM.Core.Database;

public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}