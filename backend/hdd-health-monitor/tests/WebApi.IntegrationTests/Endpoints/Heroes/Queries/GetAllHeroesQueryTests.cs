using FastEndpoints;
using hdd_health_monitor.Features.Heroes.GetAllHeroes;
using hdd_health_monitor.IntegrationTests.Common;
using hdd_health_monitor.IntegrationTests.Common.Factories;

namespace hdd_health_monitor.IntegrationTests.Endpoints.Heroes.Queries;

public class GetAllHeroesQueryTests(TestingDatabaseFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task Query_ShouldReturnAllHeroes()
    {
        // Arrange
        const int entityCount = 10;
        var entities = HeroFactory.Generate(entityCount);
        await AddRangeAsync(entities);
        var client = GetAnonymousClient();

        // Act
        var result = await client.GETAsync<GetAllHeroesEndpoint, GetAllHeroesResponse>();

        // Assert
        result.Response.IsSuccessStatusCode.Should().BeTrue();
        result.Result.Should().NotBeNull();
        result.Result!.Heroes.Should().HaveCount(entityCount);
    }
}