using hdd_health_monitor.Common.Interfaces;
using System.Security.Claims;

namespace hdd_health_monitor.Common.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string? UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}