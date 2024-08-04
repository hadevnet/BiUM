using BiUM.Specialized.Common.API;
using Microsoft.EntityFrameworkCore;

namespace BiUM.Specialized.Database;

public static class Extensions
{
    public static async Task<PaginatedApiResponse<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageStart = 0, int pageSize = 10, CancellationToken cancellationToken = default) where TDestination : class
    {
        var query = queryable.AsNoTracking();

        return new PaginatedApiResponse<TDestination>(items: await query.Skip(pageStart).Take(pageSize).ToListAsync(cancellationToken), count: await query.CountAsync(cancellationToken), pageNumber: (pageStart == 0 ? 0 : pageStart / pageSize) + 1, pageSize: pageSize);
    }
}