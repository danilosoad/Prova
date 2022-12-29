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
                var resultadoDadosMoeda = new List<DadosMoeda>();
                var resultadoDadosCotacao = new List<DadosCotacao>();
                var resultadoDadosDePara = new List<DadosDepara>();

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = ";",
                };

                //Processar DadosMoeda
                //using (var reader = new StreamReader(@"C:\DadosMoeda.csv"))
                using (var reader = new StreamReader(@"..\DadosMoeda.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<DadosMoedaMap>();
                    var dadosCsv = csv.GetRecords<DadosMoedaCsv>().Skip(1).ToList();

                    var dadosCsvConvertidos = new List<DadosMoeda>();

                    foreach (var item in dadosCsv)
                        dadosCsvConvertidos.Add(new DadosMoeda() { ID_MOEDA = item.ID_MOEDA, DATA_REF = Convert.ToDateTime(item.DATA_REF) });

                    resultadoDadosMoeda = dadosCsvConvertidos.Where(x => x.DATA_REF <= moeda.DataFim && x.DATA_REF >= moeda.DataInicio).ToList();
                }

                //Processar De-Para
                using (var reader = new StreamReader(@"..\DadosDePara.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<DadosDeParaMap>();
                    var dadosDeParaCsv = csv.GetRecords<DadosDeParaCsv>().Skip(1).ToList();

                    var dadosDeParaCsvConvertidos = new List<DadosDepara>();

                    foreach (var item in dadosDeParaCsv)
                        dadosDeParaCsvConvertidos.Add(new DadosDepara() { IdMoeda = item.IdMoeda, CodigoCotacao = Convert.ToInt32(item.CodigoCotacao) });

                    var codigosMoeda = resultadoDadosMoeda.Select(x => x.ID_MOEDA).ToList();
                    resultadoDadosDePara = dadosDeParaCsvConvertidos.Where(x => codigosMoeda.Contains(x.IdMoeda)).ToList();
                }

                //Processar Dados Cotação
                using (var reader = new StreamReader(@"..\DadosCotacao.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<DadosCotacaoMap>();
                    var dadosCotacaoCsv = csv.GetRecords<DadosCotacaoCsv>().Skip(1).ToList();

                    var dadosCotacaoCsvConvertidos = new List<DadosCotacao>();

                    foreach (var item in dadosCotacaoCsv)
                        dadosCotacaoCsvConvertidos.Add(new DadosCotacao() { ValorCotacao = Convert.ToDecimal(item.ValorCotacao), CodigoCotacao = Convert.ToInt32(item.CodigoCotacao), DataCotacao = Convert.ToDateTime(item.DataCotacao) });

                    var codigosCotacao = resultadoDadosDePara.Select(x => x.CodigoCotacao);

                    resultadoDadosCotacao = dadosCotacaoCsvConvertidos.Where(x => codigosCotacao.Contains(x.CodigoCotacao)).ToList();
                }
            }
        }
    }
}