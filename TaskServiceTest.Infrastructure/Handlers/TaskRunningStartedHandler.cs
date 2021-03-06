﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskServiceTest.Domain.Events;
using TaskServiceTest.Domain.Events.Contracts;
using TaskServiceTest.Domain.Services;

namespace TaskServiceTest.Infrastructure.Handlers
{
    public class TaskRunningStartedHandler : IDomainEventHandler<TaskRunningStartedEvent>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TaskRunningStartedHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async void Handle(TaskRunningStartedEvent @event)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                await Task.Delay(120000);

                var taskService = scope.ServiceProvider.GetRequiredService<ITaskService>();

                var task = await taskService.GetByIdAsync(@event.TaskId);
                task.TimeStamp = DateTime.UtcNow;
                task.Status = Domain.Entities.Status.finished;
                await taskService.UpdateAsync(task);
            }
        }
    }
}
