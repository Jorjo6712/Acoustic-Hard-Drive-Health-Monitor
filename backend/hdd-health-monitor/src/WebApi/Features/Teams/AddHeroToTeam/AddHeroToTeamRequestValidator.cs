namespace hdd_health_monitor.Features.Teams.AddHeroToTeam;

public class AddHeroToTeamRequestValidator : Validator<AddHeroToTeamRequest>
{
    public AddHeroToTeamRequestValidator()
    {
        RuleFor(v => v.TeamId)
            .NotEmpty();

        RuleFor(v => v.HeroId)
            .NotEmpty();
    }
}
