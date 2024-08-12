using BiUM.Infrastructure.Common.Models;

namespace BiUM.Specialized.Common.Models;

public static class Extensions
{
    public static TTranslationEntity ToTranslationEntity<TTranslationEntity>(this BaseTranslationDto translation, Guid recordId, string columnName)
        where TTranslationEntity : TranslationBaseEntity, new()
    {
        return new()
        {
            Id = translation.Id,
            RecordId = recordId,
            Column = columnName,
            LanguageId = translation.LanguageId,
            Translation = translation.Translation,
        };
    }
}