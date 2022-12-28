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
            return Ok(await _moedaService.GetMoedas());
        }
    }
}