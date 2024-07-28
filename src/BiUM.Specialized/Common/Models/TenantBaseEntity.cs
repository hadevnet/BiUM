using System.ComponentModel.DataAnnotations.Schema;
using BiUM.Infrastructure.Common.Models;

namespace BiUM.Specialized.Common.Models;

public class TenantBaseEntity : BaseEntity
{
    public override Guid Id { get; set; }

    [Column("TENANT_ID", Order = 1)]
    public Guid? TenantId { get; set; }
}