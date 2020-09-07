using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskServiceTest.Domain.Entities;

namespace TaskServiceTest.Domain.Repositories
{
    public interface ITaskRepository
    {
        IQueryable<TaskEntity> GetAll();

        Task<Guid> AddAsync(TaskEntity task);

        Task UpdateAsync(TaskEntity task);
    }
}
