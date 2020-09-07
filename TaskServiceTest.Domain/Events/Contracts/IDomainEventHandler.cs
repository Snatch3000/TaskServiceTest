using System;
using System.Collections.Generic;
using System.Text;

namespace TaskServiceTest.Domain.Events.Contracts
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
