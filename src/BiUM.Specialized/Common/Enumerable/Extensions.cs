using BiUM.Infrastructure.Common.Models;

namespace System.Linq;

public static class Extensions
{
    public static string? GetColumnTranslation<TSource>(this IEnumerable<TSource> source, string columnName)
        where TSource : TranslationBaseEntity
    {
        return source.FirstOrDefault(x => x.Column.Equals(columnName))?.Translation;
    }
}