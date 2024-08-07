using BiUM.Specialized.Common.API;
using Microsoft.EntityFrameworkCore;

namespace BiUM.Specialized.Database;

public static class Extensions
{
    public static async Task<PaginatedApiResponse<TDestination>> ToPaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int? pageStart = 0, int? pageSize = 10, CancellationToken cancellationToken = default) where TDestination : class
    {
        var query = queryable.AsNoTracking();

        return new PaginatedApiResponse<TDestination>(
            items: await query.Skip(pageStart.Value).Take(pageSize.Value).ToListAsync(cancellationToken),
            count: await query.CountAsync(cancellationToken),
            pageNumber: (pageStart.Value == 0 ? 0 : pageStart.Value / pageSize.Value) + 1,
            pageSize: pageSize.Value
        );
    }
}