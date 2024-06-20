using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiUM.Core.Common;

public class BaseTenantEntity : BaseEntity
{
    [Required]
    [Column("ID", Order = 0)]
    public override Guid Id { get; set; }

    [Column("TENANT_ID", Order = 1)]
    public Guid? TenantId { get; set; }
}