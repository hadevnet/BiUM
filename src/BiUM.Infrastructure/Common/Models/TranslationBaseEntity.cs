namespace BiUM.Infrastructure.Common.Models;

public class TranslationBaseEntity
{
    public required Guid Id { get; set; }

    public required string Column { get; set; }

    public required Guid LanguageId { get; set; }

    public string? Translation { get; set; }

    public Guid BaseTranslationEntity() => Id = Guid.NewGuid();
}