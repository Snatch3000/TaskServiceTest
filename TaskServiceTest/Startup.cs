using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaskServiceTest.Domain.Events;
using TaskServiceTest.Domain.Events.Contracts;
using TaskServiceTest.Domain.Repositories;
using TaskServiceTest.Domain.Services;
using TaskServiceTest.Infrastructure.Handlers;
using TaskServiceTest.Repositories;
using TaskServiceTest.Services;

namespace TaskServiceTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<TaskDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TaskDbConnectionString")));

            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddScoped<ITaskService, TaskService>();

            services.AddTransient<IDomainEventHandler<TaskCreatedEvent>, TaskCreatedHandler>();
            services.AddTransient<IDomainEventHandler<TaskRunningStartedEvent>, TaskRunningStartedHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
