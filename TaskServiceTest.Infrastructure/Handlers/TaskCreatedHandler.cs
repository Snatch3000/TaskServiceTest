using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskServiceTest.Domain.Events;
using TaskServiceTest.Domain.Events.Contracts;
using TaskServiceTest.Domain.Services;

namespace TaskServiceTest.Infrastructure.Handlers
{
    public class TaskCreatedHandler : IDomainEventHandler<TaskCreatedEvent>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TaskCreatedHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async void Handle(TaskCreatedEvent @event)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var taskService = scope.ServiceProvider.GetRequiredService<ITaskService>();
            
                var task = await taskService.GetByIdAsync(@event.TaskId);
                task.TimeStamp = DateTime.UtcNow;
                task.Status = Domain.Entities.Status.running;
                await taskService.UpdateAsync(task);

                DomainEvents.Raise(new TaskRunningStartedEvent(task.Id));
            }
            
        }
    }
}
