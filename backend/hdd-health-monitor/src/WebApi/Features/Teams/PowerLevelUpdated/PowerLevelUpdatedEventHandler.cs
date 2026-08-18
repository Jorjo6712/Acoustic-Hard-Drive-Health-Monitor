using Ardalis.Specification.EntityFrameworkCore;
using hdd_health_monitor.Common.Domain.Base.EventualConsistency;
using hdd_health_monitor.Common.Domain.Heroes;
using hdd_health_monitor.Common.Domain.Teams;

namespace hdd_health_monitor.Features.Teams.PowerLevelUpdated;

public class PowerLevelUpdatedEventHandler(
    IServiceScopeFactory scopeFactory,
    ILogger<PowerLevelUpdatedEventHandler> logger)
    : IEventHandler<PowerLevelUpdatedEvent>
{
    public async Task HandleAsync(PowerLevelUpdatedEvent eventModel, CancellationToken ct)
    {
        logger.PowerLevelUpdated(eventModel.Hero.Name, eventModel.Hero.PowerLevel);

        using var scope = scopeFactory.CreateScope();
        var dbContext = scope.Resolve<ApplicationDbContext>();


        var hero = await dbContext.Heroes.FirstAsync(h => h.Id == eventModel.Hero.Id,
            cancellationToken: ct);

        if (hero.TeamId is null)
        {
            logger.HeroNotOnTeam(eventModel.Hero.Name);
            return;
        }

        var team = dbContext.Teams
            .WithSpecification(TeamSpec.ById(hero.TeamId.Value))
            .FirstOrDefault();

        if (team is null)
            throw new EventualConsistencyException(PowerLevelUpdatedEvent.TeamNotFound);

        team.ReCalculatePowerLevel();
        await dbContext.SaveChangesAsync(ct);
    }
}

// Compile-time logging: the source generator emits a level-checked, allocation-free
// method, which also satisfies CA1873 (the generated call is not an ILogger.Log* shape).
internal static partial class PowerLevelUpdatedEventHandlerLog
{
    [LoggerMessage(LogLevel.Information,
        "PowerLevelUpdatedEventHandler: {HeroName} power updated to {PowerLevel}")]
    public static partial void PowerLevelUpdated(this ILogger logger, string heroName, int powerLevel);

    [LoggerMessage(LogLevel.Information, "Hero {HeroName} is not on a team - nothing to do")]
    public static partial void HeroNotOnTeam(this ILogger logger, string heroName);
}
