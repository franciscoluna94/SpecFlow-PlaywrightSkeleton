using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using BoDi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System.Reflection;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowSkeleton.Support
{
    public class DependencySetup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            RegisterPages(services);

            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton((x) =>
            {
                var specFlowContainer = x.GetRequiredService<IObjectContainer>();
                var specflowOutputHelper = specFlowContainer.Resolve<ISpecFlowOutputHelper>();
                return specflowOutputHelper;
            });

            return services;
        }

        private static void RegisterPages(ServiceCollection services)
        {
            var pages = Assembly.Load(Assembly.GetExecutingAssembly().FullName).GetTypes().Where(x => x.Name.EndsWith("Page"));

            foreach (var page in pages)
            {
                services.AddTransient(page);
            }
        }
    }
}
