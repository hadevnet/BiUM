using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace BiUM.Infrastructure.Services.Authorization;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private string? userId => _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public Guid? UserId => !string.IsNullOrWhiteSpace(userId) ? Guid.Parse(userId) : null;

    public Guid? TenantId => !string.IsNullOrWhiteSpace(userId) ? Guid.Parse(userId) : null;
}