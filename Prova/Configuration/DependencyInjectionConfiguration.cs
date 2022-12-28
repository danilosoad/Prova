using Prova.Infra.IoC;

namespace Prova.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);
        }
    }
}