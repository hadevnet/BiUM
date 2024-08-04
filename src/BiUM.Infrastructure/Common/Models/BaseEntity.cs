using System.ComponentModel.DataAnnotations.Schema;
using BiUM.Infrastructure.Common.Events;

namespace BiUM.Infrastructure.Common.Models;

public class BaseEntity : BaseAuditableEntity
{
    public override Guid Id { get; set; }
    public bool Active { get; set; } = true;
    public DateOnly Created { get; set; }
    public TimeOnly CreatedTime { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateOnly? Updated { get; set; }
    public TimeOnly? UpdatedTime { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool Test { get; set; } = false;

    public BaseEntity() => Id = Guid.NewGuid();

    [NotMapped]
    private readonly List<BaseEvent> DomainEvents = [];

    public void AddDomainEvent(BaseEvent baseEvent)
    {
        DomainEvents.Add(baseEvent);
    }
}