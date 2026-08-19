namespace hdd_health_monitor.Features.Teams.GetAllTeams;

public record GetAllTeamsResponse(List<GetAllTeamsResponse.TeamDto> Teams)
{
    public record TeamDto(Guid Id, string Name);
}
