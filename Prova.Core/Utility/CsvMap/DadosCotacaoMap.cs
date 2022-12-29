using CsvHelper.Configuration;
using Prova.Core.Utility.CsvHelper;

namespace Prova.Core.Utility.CsvMap
{
    public class DadosCotacaoMap : ClassMap<DadosCotacaoCsv>
    {
        public DadosCotacaoMap()
        {
            Map(x => x.ValorCotacao).Name("vlr_cotacao").Index(0);
            Map(x => x.CodigoCotacao).Name("cod_cotacao").Index(1);
            Map(x => x.DataCotacao).Name("dat_cotacao").Index(2);
        }
    }
}