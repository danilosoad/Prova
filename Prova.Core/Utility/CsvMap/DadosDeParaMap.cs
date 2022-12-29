using CsvHelper.Configuration;
using Prova.Core.Utility.CsvHelper;

namespace Prova.Core.Utility.CsvMap
{
    public class DadosDeParaMap : ClassMap<DadosDepara>
    {
        public DadosDeParaMap()
        {
            Map(x => x.IdMoeda).Name("DadosCotacao_ID_MOEDA").Index(0);
            Map(x => x.CodigoCotacao).Name("DadosCotacao_cod_cotacao").Index(1);
        }
    }
}