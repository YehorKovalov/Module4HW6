using System.IO;
using Microsoft.Extensions.Configuration;
using SongLibrary.Services.Abstractions;

namespace SongLibrary.Services
{
    public class ConfigurationServices : IConfigurationServices
    {
        private const string ConfigPath = "appsettings.json";
        private string _connectionString;

        public ConfigurationServices()
        {
            Init();
        }

        public string ConnectionString => _connectionString;

        private void Init()
        {
            const string connectionStringName = "DefaultConnection";
            var builder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();

            builder.SetBasePath(currentDirectory);
            builder.AddJsonFile(ConfigPath);
            var config = builder.Build();
            _connectionString = config.GetConnectionString(connectionStringName);
        }
    }
}