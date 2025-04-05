using Microsoft.Extensions.Configuration;

namespace TestWebApp.Common
{

    public static class ConfigurationGetter
    {
        public static IConfiguration GetConfiguration()
        {
            var currentEnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var environmentName = currentEnvironmentName ?? "Production";

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static string GetConnectionString()
        {
            var configuration = ConfigurationGetter.GetConfiguration();

            return configuration["ConnectionString"];
        }
    }
}