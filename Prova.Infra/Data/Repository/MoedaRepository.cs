using Microsoft.EntityFrameworkCore;
using Prova.Core.Entity.Moeda;
using Prova.Core.Entity.Moeda.Repository;
using Prova.Infra.Data.DataConxtext;

namespace Prova.Infra.Data.Repository
{
    public class MoedaRepository : IMoedaRepository
    {
        private readonly DataContext _context;

        public MoedaRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task AddAsync(List<Moeda> moedas)
        {
            await _context.AddRangeAsync(moedas);
            await _context.SaveChangesAsync();
        }

        public async Task<Moeda> GetLastRecord()
        {
            return await _context.Moedas.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}