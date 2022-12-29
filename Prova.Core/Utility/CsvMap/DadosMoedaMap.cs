using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Prova.Core.Utility.CsvHelper;

namespace Prova.Core.Utility.CsvMap
{
    public class DadosMoedaMap : ClassMap<DadosMoedaCsv>
    {
        public DadosMoedaMap()
        {
            Map(x => x.ID_MOEDA).Name("ID_MOEDA").Index(0);
            //Map(x => x.DATA_REF).Name("DATA_REF").Index(1).TypeConverter<DateTimeConverter>().TypeConverterOption.Format("yyyy-MM-dd");
            Map(x => x.DATA_REF).Name("DATA_REF").Index(1);
        }
    }
}