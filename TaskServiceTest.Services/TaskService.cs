using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TaskServiceTest.Domain.Entities;
using TaskServiceTest.Domain.Repositories;
using TaskServiceTest.Domain.Services;
using Microsoft.EntityFrameworkCore;
using TaskServiceTest.Infrastructure;
using TaskServiceTest.Domain.Events;

namespace TaskServiceTest.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskEntity> GetByIdAsync(Guid id)
        {
            return await _taskRepository.GetAll().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _taskRepository.GetAll().ToListAsync();
        }

        public async Task<Guid> AddAsync(TaskEntity task)
        {
            var id = await _taskRepository.AddAsync(task);

            DomainEvents.Raise(new TaskCreatedEvent(id));

            return id;
        }

        public async Task UpdateAsync(TaskEntity task)
        {
            await _taskRepository.UpdateAsync(task);
        }
    }
}
