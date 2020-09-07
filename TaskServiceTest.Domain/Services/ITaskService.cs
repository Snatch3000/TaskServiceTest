using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskServiceTest.Domain.Entities;

namespace TaskServiceTest.Domain.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> GetAllAsync();

        Task<TaskEntity> GetByIdAsync(Guid id);

        Task<Guid> AddAsync(TaskEntity task);

        Task UpdateAsync(TaskEntity task);
    }
}
