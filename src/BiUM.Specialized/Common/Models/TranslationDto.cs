using BiUM.Infrastructure.Common.Models;
using BiUM.Specialized.Mapping;

namespace BiUM.Specialized.Common.Models;

public class TranslationDto : IMapFrom<TranslationBaseEntity>
{
    public required Guid Id { get; set; }
    public required Guid LanguageId { get; set; }
    public string? Column { get; set; }
    public string? Translation { get; set; }
    public int _rowStatus { get; set; }
}