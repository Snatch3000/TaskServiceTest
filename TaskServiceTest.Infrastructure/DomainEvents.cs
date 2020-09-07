using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskServiceTest.Domain.Events.Contracts;

namespace TaskServiceTest.Infrastructure
{
    public static class DomainEvents
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (ServiceProvider != null)
            {
                foreach (var handler in (IEnumerable<IDomainEventHandler<T>>)ServiceProvider.GetService(typeof(IEnumerable<IDomainEventHandler<T>>)))
                {
                    handler.Handle(args);
                }
            }
        }
    }
}
