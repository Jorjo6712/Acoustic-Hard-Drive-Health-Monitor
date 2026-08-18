namespace hdd_health_monitor.Features.Heroes.CreateHero;

public record CreateHeroRequest(
    string Name,
    string Alias,
    IEnumerable<CreateHeroRequest.HeroPowerDto> Powers)
{
    public record HeroPowerDto(string Name, int PowerLevel);
}
