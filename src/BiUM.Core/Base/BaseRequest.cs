using MediatR;

namespace BiUM.Core.Base;

public record BaseRequestDto<TType> : IRequest<ApiResponse<TType>>
{
    public required string CorrelationId { get; set; }
    public string? LanguageCode { get; set; }
}

public record BaseCommandDto<TType> : BaseRequestDto<TType>
{
}

public record BaseQueryDto<TType> : BaseRequestDto<TType>
{
}