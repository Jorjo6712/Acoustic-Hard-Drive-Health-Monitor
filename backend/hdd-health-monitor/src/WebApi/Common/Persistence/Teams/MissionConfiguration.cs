using Microsoft.EntityFrameworkCore.Metadata.Builders;
using hdd_health_monitor.Common.Domain.Teams;
using hdd_health_monitor.Common.Persistence.Heroes;

namespace hdd_health_monitor.Common.Persistence.Teams;

public class MissionConfiguration : AuditableConfiguration<Mission>
{
    public override void PostConfigure(EntityTypeBuilder<Mission> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Description)
            .HasMaxLength(Mission.DescriptionMaxLength)
            .IsRequired();
    }
}