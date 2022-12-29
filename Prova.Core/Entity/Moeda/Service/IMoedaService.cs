namespace Prova.Core.Entity.Moeda.Service
{
    public interface IMoedaService
    {
        Task AddMoeda(List<Moeda> moedas);

        Task<Moeda> GetMoedas();

        Task Teste();
    }
}