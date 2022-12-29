namespace Prova.Core.Entity.Moeda.Repository
{
    public interface IMoedaRepository
    {
        Task AddAsync(List<Moeda> moedas);

        Task<Moeda> GetLastRecord();
    }
}