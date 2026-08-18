namespace hdd_health_monitor.Features.Teams.CompleteMission;

public class CompleteMissionRequestValidator : Validator<CompleteMissionRequest>
{
    public CompleteMissionRequestValidator()
    {
        RuleFor(v => v.TeamId)
            .NotEmpty();
    }
}
