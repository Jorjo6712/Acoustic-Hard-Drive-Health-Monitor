using hdd_health_monitor.Common.Domain.Heroes;
using hdd_health_monitor.Common.Domain.Teams;

namespace hdd_health_monitor.Common.Persistence;

// TODO: New strongly typed IDs should be registered here

[EfCoreConverter<HeroId>]
[EfCoreConverter<TeamId>]
[EfCoreConverter<MissionId>]
internal sealed partial class VogenEfCoreConverters;