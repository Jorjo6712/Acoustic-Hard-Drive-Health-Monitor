using System.Reflection;

namespace hdd_health_monitor.ArchitectureTests.Common;

public abstract class TestBase
{
    protected const string DomainAssemblyName = "Domain";
    protected const string CommandsAssemblyName = "Commands";
    protected const string QueriesAssemblyName = "Queries";
    
    protected static readonly Assembly RootAssembly = typeof(hdd_health_monitor.Program).Assembly;
}