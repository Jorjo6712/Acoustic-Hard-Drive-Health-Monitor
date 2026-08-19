namespace hdd_health_monitor.Common.Interfaces;

public interface IFeature
{
    static abstract void ConfigureServices(IServiceCollection services, IConfiguration config);
}