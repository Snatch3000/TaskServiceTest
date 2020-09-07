using System;
using System.Collections.Generic;
using System.Text;
using TaskServiceTest.Domain.Entities;
using TaskServiceTest.Domain.Events.Contracts;

namespace TaskServiceTest.Domain.Events
{
    public class TaskCreatedEvent : IDomainEvent
    {
        public Guid TaskId { get; set; }

        public TaskCreatedEvent(Guid id)
        {
            TaskId = id;
        }
    }
}
