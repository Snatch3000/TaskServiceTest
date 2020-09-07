using System;
using System.Collections.Generic;
using System.Text;
using TaskServiceTest.Domain.Events.Contracts;

namespace TaskServiceTest.Domain.Events
{
    public class TaskRunningStartedEvent : IDomainEvent
    {
        public Guid TaskId { get; set; }

        public TaskRunningStartedEvent(Guid id)
        {
            TaskId = id;
        }
    }
}
