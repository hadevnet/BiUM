using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BiUM.Infrastructure.Common.Models;

public class TranslationBaseEntity
{
    [Required]
    [Column("ID", Order = 1)]
    public required Guid Id { get; set; }

    [Required]
    [Column("RECORD_ID", Order = 2)]
    public required Guid RecordId { get; set; }

    [Required]
    [Column("COLUMN", Order = 3)]
    public required string Column { get; set; }

    [Required]
    [Column("LANGUAGE_ID", Order = 4)]
    public required Guid LanguageId { get; set; }

    [Column("TRANSLATION", Order = 5)]
    public string? Translation { get; set; }

    public Guid BaseTranslationEntity() => Id = Guid.NewGuid();
}