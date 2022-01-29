using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SongLibrary.Domain;
using SongLibrary.Services;
using SongLibrary.Services.Abstractions;

namespace SongLibrary
{
    public class Startup
    {
        public async Task Run()
        {
            var serviceProvider = ConfigureServices();
            var app = serviceProvider?.GetService<Application>();
            await app?.Run();
        }

        public IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfigurationServices, ConfigurationServices>();
            serviceCollection.AddTransient<Application>();

            serviceCollection.AddDbContext<SongLibraryDbContext>(o =>
            {
                o.UseSqlServer(
                    new ConfigurationServices().ConnectionString,
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}
