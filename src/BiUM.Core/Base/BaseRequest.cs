namespace BiUM.Core.Base;

public record BaseRequestDto
{
    public required string CorrelationId { get; set; }
    public string? LanguageCode { get; set; }
}

public record BaseCommandDto : BaseRequestDto
{
}

public record BaseQueryDto : BaseRequestDto
{
}