using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Prova.API.ViewModels;
using Prova.API.ViewModels.Adapters;
using Prova.Core.Entity.Moeda.Service;

namespace Prova.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvaController : ControllerBase
    {
        private readonly IMoedaService _moedaService;

        public ProvaController(IMoedaService moedaService)
        {
            _moedaService = moedaService;
            InitJob();
        }

        [HttpPost]
        public async Task<IActionResult> AddItemFila([FromBody] List<MoedaViewModel> viewModels)
        {
            var moedas = viewModels.ConverterParaMoeda();
            await _moedaService.AddMoeda(moedas);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetItemFila()
        {
            var response = await _moedaService.GetMoedas();

            if (response != null)
                return Ok(response);

            return NoContent();
        }

        private async void InitJob()
        {
            //RecurringJob.AddOrUpdate(() => _moedaService.GetMoedas(), Cron.MinuteInterval(2));
            RecurringJob.AddOrUpdate(() => _moedaService.Teste(), Cron.Minutely());
        }
    }
}