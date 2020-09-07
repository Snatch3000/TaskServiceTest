using System;
using System.Collections.Generic;
using System.Text;

namespace TaskServiceTest.Domain.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
