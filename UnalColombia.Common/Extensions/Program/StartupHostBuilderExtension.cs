using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace UnalColombia.Common.Extensions.Program
{
    public static class StartupHostBuilderExtension
    {
        public static IHostBuilder SetAppSettings(this IHostBuilder configuration, string environmentName, string configName = "appsettings")
        {
            string configName2 = configName;
            string environmentName2 = environmentName;
            return configuration.ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration
                    .AddJsonFile(configName2 + ".json", optional: false, reloadOnChange: false)
                    .AddJsonFile(configName2 + "." + environmentName2 + ".json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables();
            });
        }
    }
}
