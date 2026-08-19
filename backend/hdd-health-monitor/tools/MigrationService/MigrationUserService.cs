using hdd_health_monitor.Common.Interfaces;

namespace MigrationService;

public class MigrationUserService : ICurrentUserService
{
    public string? UserId => "MigrationService";
}