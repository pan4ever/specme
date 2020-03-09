using Microsoft.AspNetCore.Components;
using Specme.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Specme.Client.Services
{
    public class ProjectService
    {
        HttpClient http;

        public ProjectService(
            HttpClient http
        ) {
            this.http = http;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await http.GetJsonAsync<Project[]>("Project");
        }

        public async Task<Project> GetOne(string id)
        {
            return await http.GetJsonAsync<Project>($"Project?id={id}");
        }

        public async Task<Project> Add(Project newProject)
        {
            return await http.PostJsonAsync<Project>("Project", newProject);
        }

        public async Task<Project> Update(Project project)
        {
            var url = $"Project?id={project.UUID}";
            return await http.PutJsonAsync<Project>(url, project);
        }

        public async Task Remove(Project project)
        {
            var url = $"Project?id={project.UUID}";
            await http.DeleteAsync(url);
        }
    }
}
