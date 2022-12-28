using Prova.Core.Entity.Moeda;

namespace Prova.API.ViewModels.Adapters
{
    public static class MoedaAdapter
    {
        public static Moeda ConverterParaMoeda(this MoedaViewModel viewModel)
        {
            return new Moeda(viewModel.Moeda, viewModel.DataInicio, viewModel.DataFim);
        }

        public static List<Moeda> ConverterParaMoeda(this List<MoedaViewModel> viewModels)
        {
            var moedas = new List<Moeda>();

            foreach (var item in viewModels)
                moedas.Add(item.ConverterParaMoeda());

            return moedas;
        }
    }
}