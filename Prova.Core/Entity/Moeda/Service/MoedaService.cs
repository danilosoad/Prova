using Prova.Core.Entity.Moeda.Repository;

namespace Prova.Core.Entity.Moeda.Service
{
    public class MoedaService : IMoedaService
    {
        private readonly IMoedaRepository _moedaRepository;

        public MoedaService(IMoedaRepository moedaRepository)

        {
            _moedaRepository = moedaRepository;
        }

        public async Task AddMoeda(List<Moeda> moedas)
        {
           await _moedaRepository.AddAsync(moedas);
        }

        public async Task<List<Moeda>> GetMoedas()
        {
            return await _moedaRepository.Get(); 
        }
    }
}