using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskServiceTest.Domain.Entities;
using TaskServiceTest.Domain.Repositories;

namespace TaskServiceTest.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TaskEntity> GetAll()
        {
            return _dbContext.Tasks.AsQueryable();
        }

        public async Task<Guid> AddAsync(TaskEntity task)
        {
            if (task.Id == Guid.Empty)
            {
                task.Id = new Guid();
            }

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();

            return task.Id;
        }        

        public async Task UpdateAsync(TaskEntity task)
        {
            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();
        }
    }
}
