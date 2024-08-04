namespace BiUM.Infrastructure.Common.Models;

public class TenantBaseEntity : BaseEntity
{
    public override Guid Id { get; set; }

    public Guid TenantId { get; set; }
}