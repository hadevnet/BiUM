using MediatR;

namespace BiUM.Core.Base;

public record BaseRequestDto<TType> : IRequest<ApiResponse<TType>>
{
    public required Guid CorrelationId { get; set; }
    public string? LanguageCode { get; set; }
}

public record BaseCommandDto<TType> : BaseRequestDto<TType>
{
}

public record BaseCommandTenantDto<TType> : BaseRequestDto<TType>
{
    public Guid? TenantId { get; set; }
}

public record BaseQueryDto<TType> : BaseRequestDto<TType>
{
}

public record BaseQueryTenantDto<TType> : BaseRequestDto<TType>
{
    public Guid? TenantId { get; set; }
}