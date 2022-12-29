using CsvHelper;
using CsvHelper.Configuration;
using Prova.Core.Entity.Moeda.Repository;
using Prova.Core.Utility.CsvHelper;
using Prova.Core.Utility.CsvMap;
using System.Globalization;

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

        public async Task<Moeda> GetMoedas()
        {
            return await _moedaRepository.GetLastRecord();
        }

        public async Task Teste()
        {
            var moeda = await GetMoedas();

            if (moeda != null)
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = ";",
                };

                using (var reader = new StreamReader(@"C:\DadosMoeda.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<DadosMoedaMap>();
                    var dadosCsv = csv.GetRecords<DadosMoedaCsv>().Skip(1).ToList();


                    foreach (var dado in dadosCsv)
                        Console.WriteLine($"Moeda: {dado.ID_MOEDA}, Data: {dado.DATA_REF}");
                }
            }
        }
    }
}