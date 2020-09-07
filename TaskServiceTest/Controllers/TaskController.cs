using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskServiceTest.Domain.Entities;
using TaskServiceTest.Domain.Repositories;
using TaskServiceTest.Domain.Services;
using TaskServiceTest.Models;

namespace TaskServiceTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("task")]
        public async Task<IActionResult> Create()
        {
            var task = new TaskEntity()
            {
                Status = Status.created,
                TimeStamp = DateTime.UtcNow
            };

            var id = await _taskService.AddAsync(task);

            return StatusCode(202, id);
        }

        [HttpGet("task/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var task = await _taskService.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            var vm = new TaskViewModel()
            {
                Status = task.Status.ToString(),
                TimeStamp = task.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return Ok(vm);
        }
    }
}