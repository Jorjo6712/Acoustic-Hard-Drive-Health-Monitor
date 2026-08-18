namespace hdd_health_monitor.Common.Features;

public interface IEndpoint
{
    static abstract void MapEndpoint(IEndpointRouteBuilder endpoints);
}