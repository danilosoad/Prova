using Microsoft.Extensions.DependencyInjection;
using Prova.Core.Entity.Moeda.Repository;
using Prova.Core.Entity.Moeda.Service;
using Prova.Infra.Data.DataConxtext;
using Prova.Infra.Data.Repository;

namespace Prova.Infra.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IMoedaService, MoedaService>();

            //Data
            services.AddScoped<DataContext>();
            services.AddScoped<IMoedaRepository, MoedaRepository>();
        }
    }
}