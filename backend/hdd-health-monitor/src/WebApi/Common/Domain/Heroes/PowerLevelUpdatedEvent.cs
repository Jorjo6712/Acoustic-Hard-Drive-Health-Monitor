using hdd_health_monitor.Common.Domain.Base.EventualConsistency;

namespace hdd_health_monitor.Common.Domain.Heroes;

public record PowerLevelUpdatedEvent(Hero Hero) : IEvent
{
    public static readonly Error TeamNotFound = EventualConsistencyError.From(
        code: "PowerLeveUpdated.TeamNotFound",
        description: "Team not found");
}