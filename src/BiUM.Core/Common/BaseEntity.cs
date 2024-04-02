using System.ComponentModel.DataAnnotations.Schema;

namespace BiUM.Core.Common;

public class BaseEntity
{
    public int Id { get; set; }

    [NotMapped]
    public List<BaseEvent> DomainEvents = new();
}