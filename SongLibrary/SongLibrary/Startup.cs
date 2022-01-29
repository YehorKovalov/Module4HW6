using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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

            return serviceCollection.BuildServiceProvider();
        }
    }
}
