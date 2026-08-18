namespace hdd_health_monitor.Common.Domain.Base.Interfaces;

public interface IAggregateRoot
{
    void AddDomainEvent(IEvent domainEvent);

    IReadOnlyList<IEvent> PopDomainEvents();
}