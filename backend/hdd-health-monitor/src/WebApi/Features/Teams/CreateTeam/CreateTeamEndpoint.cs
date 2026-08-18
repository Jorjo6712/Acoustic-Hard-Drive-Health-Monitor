using hdd_health_monitor.Common.Domain.Teams;

namespace hdd_health_monitor.Features.Teams.CreateTeam;

public class CreateTeamEndpoint(ApplicationDbContext dbContext)
    : Endpoint<CreateTeamRequest>
{
    public override void Configure()
    {
        Post("/");
        Group<TeamsGroup>();
        Description(x => x.WithName("CreateTeam"));
    }

    public override async Task HandleAsync(CreateTeamRequest req, CancellationToken ct)
    {
        var team = Team.Create(req.Name);

        dbContext.Teams.Add(team);
        await dbContext.SaveChangesAsync(ct);

        await Send.NoContentAsync(ct);
    }
}
