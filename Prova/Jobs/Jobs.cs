using Hangfire;
using Prova.Core.Entity.Moeda.Service;

namespace Prova.API.Jobs
{
    public class Jobs
    {
        private readonly IMoedaService _moedaService;

        public Jobs(IMoedaService moedaService)
        {
            _moedaService = moedaService;
        }

        private void InitJob()
        {
            RecurringJob.AddOrUpdate(() => _moedaService.GetMoedas(), Cron.MinuteInterval(2));
        }
    }
}