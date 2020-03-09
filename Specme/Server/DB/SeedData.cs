using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Specme.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specme.Server.DB
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbOptions = serviceProvider.GetRequiredService<DbContextOptions<SpecmeContext>>();
            using var context = new SpecmeContext(dbOptions);

            if (context.Projects.Any())
            {
                return;
            }

            context.Projects.AddRange(
                new Project
                {
                    UUID = Guid.NewGuid().ToString(),
                    Title = "Front",
                    Description = "A great front"
                },
                new Project
                {
                    UUID = Guid.NewGuid().ToString(),
                    Title = "API",
                    Description = "A great API"
                }
            );

            context.SaveChanges();
        }
    }
}
