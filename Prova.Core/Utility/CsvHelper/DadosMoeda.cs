using CsvHelper.Configuration.Attributes;

namespace Prova.Core.Utility.CsvHelper
{
    public class DadosMoeda
    {
        [Index(0)]
        [Name("ID_MOEDA")]
        public string ID_MOEDA { get; set; }

        [Index(1)]
        [Name("DATA_REF")]
        public DateTime DATA_REF { get; set; }
    }
}