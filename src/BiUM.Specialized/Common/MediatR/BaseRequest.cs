using BiUM.Specialized.Consts;
using MediatR;

namespace BiUM.Specialized.Common.MediatR;

public record BaseRequestDto<TType> : IRequest<TType>
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    public Guid LanguageId { get; set; } = Ids.Language.English.Id;
}