
namespace Ordering.API.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {

            _domainEvents.Add(domainEvent);
        }
        //What is this part
        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequeueEvents = _domainEvents.ToArray();
            Console.WriteLine("Testing");
            _domainEvents.Clear();

            return dequeueEvents;
        }

       
    }
}
