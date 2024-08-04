using BiUM.Specialized.Common.API;

namespace BiUM.Specialized.Common.MediatR;

public record BaseCommand<TType> : BaseRequestDto<TType>
{
}

public record BaseCommandDto : BaseCommand<ApiEmptyResponse>
{
}

public record BaseCommandResponseDto<TType> : BaseCommand<ApiResponse<TType>>
{
}

public record BaseCommandTenantDto : BaseCommandDto
{
    public Guid? TenantId { get; set; }
}

public record BaseCommandTenantResponseDto<TType> : BaseCommandResponseDto<TType>
{
    public Guid? TenantId { get; set; }
}