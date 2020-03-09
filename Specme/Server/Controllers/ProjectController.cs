using Specme.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Specme.Server.DB;
using Microsoft.EntityFrameworkCore;

namespace Specme.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> logger;
        private readonly SpecmeContext context;

        public ProjectController(
            ILogger<ProjectController> logger,
            SpecmeContext context
            )
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Project>> GetAll() => 
            await context.Projects.ToListAsync();


        [HttpGet]
        [Route("{id}")]
        public async Task<Project> Get(int id)
        {
            return await context.Projects.FindAsync(id);
        }

        [HttpPost]
        [Route("")]
        public async Task<Project> Add(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.UUID))
            {
                project.UUID = Guid.NewGuid().ToString();
            }
            await context.AddAsync(project);
            await context.SaveChangesAsync();
            return project;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Project> Update(Project project)
        {
            context.Update(project);
            await context.SaveChangesAsync();
            return project;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Project> Delete(string id)
        {
            var project = context.Find<Project>(id);
            context.Remove(project);
            await context.SaveChangesAsync();
            return project;
        }
    }
}
