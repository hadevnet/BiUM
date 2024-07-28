using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiUM.Specialized.Common.Models;

public class TranslationBaseEntity
{
    [Required]
    [Column("ID", Order = 1)]
    public Guid Id { get; set; }

    [Column("COLUMN", Order = 3)]
    public required string Column { get; set; }

    [Required]
    [Column("LANGUAGE_ID", Order = 4)]
    public Guid LanguageId { get; set; }

    [Column("TRANSLATION", Order = 5)]
    public string? Translation { get; set; }

    public Guid BaseTranslationEntity() => Id = Guid.NewGuid();
}