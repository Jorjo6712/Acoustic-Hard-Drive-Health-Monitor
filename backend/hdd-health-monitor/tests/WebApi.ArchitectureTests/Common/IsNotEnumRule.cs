using Mono.Cecil;

namespace hdd_health_monitor.ArchitectureTests.Common;

public class IsNotEnumRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type) => !type.IsEnum;
}