using BiUM.Specialized.Common.API;

namespace BiUM.Specialized.Common.MediatR;

public record BaseQuery<TType> : BaseRequestDto<TType>
{
    public Guid? Id { get; set; }
    public string? Q { get; set; }
    public int? PageStart { get; set; }
    public int? PageSize { get; set; }
}

public record BaseQueryDto<TType> : BaseQuery<ApiResponse<TType>>
{
}

public record BasePaginatedQueryDto<TType> : BaseQuery<PaginatedApiResponse<TType>>
{
}

public record BaseForValuesQueryDto<TType> : BaseQuery<ApiResponse<IList<TType>>>
{
    public IReadOnlyList<Guid>? Ids { get; set; }
}

public record BasePaginatedForValuesQueryDto<TType> : BasePaginatedQueryDto<TType>
{
    public IReadOnlyList<Guid>? Ids { get; set; }
}

public record BaseQueryTenantDto<TType> : BaseQueryDto<TType>
{
    public Guid? TenantId { get; set; }
}

public record BasePaginatedQueryTenantDto<TType> : BasePaginatedQueryDto<TType>
{
    public Guid? TenantId { get; set; }
}