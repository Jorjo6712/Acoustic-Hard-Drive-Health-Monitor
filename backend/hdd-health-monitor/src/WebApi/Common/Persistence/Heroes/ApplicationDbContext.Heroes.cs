using hdd_health_monitor.Common.Domain.Heroes;

// Preserve the namespace across partial classes
// ReSharper disable once CheckNamespace
namespace hdd_health_monitor.Common.Persistence;

public partial class ApplicationDbContext
{
    public DbSet<Hero> Heroes => AggregateRootSet<Hero>();
}