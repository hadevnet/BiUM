using MediatR;

namespace BiUM.Core.Base;

public record BaseRequestDto<TType> : IRequest<TType>
{
    public required Guid CorrelationId { get; set; }
    public string? LanguageCode { get; set; }
}

public record BaseCommandDto : BaseRequestDto<ApiEmptyResponse>
{
}

public record BaseCommandTenantDto : BaseCommandDto
{
    public Guid? TenantId { get; set; }
}

public record BaseQueryDto<TType> : BaseRequestDto<ApiResponse<TType>>
{
    public Guid? Id { get; set; }
}

public record BaseQueryTenantDto<TType> : BaseQueryDto<TType>
{
    public Guid? TenantId { get; set; }
}