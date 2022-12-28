namespace Prova.Core.Entity.Moeda
{
    public class Moeda : BaseEntity
    {
        protected Moeda()
        { }

        public Moeda(string moeda, DateTime dataInicio, DateTime dataFim)
        {
            Id = 0;
            MoedaTeste = moeda;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public string MoedaTeste { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}