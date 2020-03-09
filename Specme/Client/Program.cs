using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Specme.Client.Models;
using Blazorise;
using Blazorise.Bootstrap;
using Specme.Client.Services;

namespace Specme.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // DI
            builder.Services.AddSingleton<AppState>();
            builder.Services.AddSingleton<ProjectService>();

            builder.Services
                  .AddBlazorise(options =>
                  {
                      options.ChangeTextOnKeyPress = true;
                  })
                  .AddBootstrapProviders();

            var host = builder.Build();

            host.Services
                .UseBootstrapProviders();

            await host.RunAsync();
        }
    }
}
