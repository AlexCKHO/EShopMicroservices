﻿
namespace Ordering.API.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        public IReadOnlyList<IDomainEvent> DomainEvents => throw new NotImplementedException();

        public IDomainEvent[] ClearDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}
