namespace BiUM.Core.Authorization;

public interface ICurrentUserService
{
    Guid? UserId { get; }

    Guid? TenantId { get; }
}