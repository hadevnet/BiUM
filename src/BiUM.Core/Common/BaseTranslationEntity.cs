using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiUM.Core.Common;

public class BaseTranslationEntity : CoreId
{
    [Required]
    [Column("ID", Order = 1)]
    public override Guid Id { get; set; }

    [Required]
    [Column("LANGUAGE_ID", Order = 3)]
    public Guid LanguageId { get; set; }

    [Column("TRANSLATION", Order = 4)]
    public string? Translation { get; set; }

    public BaseTranslationEntity() => Id = Guid.NewGuid();
}