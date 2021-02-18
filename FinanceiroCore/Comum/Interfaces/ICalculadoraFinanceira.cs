using System.Threading.Tasks;
using FinanceiroCore.RecursosExternos.Interfaces;

namespace FinanceiroCore.Comum.Interfaces
{
    public interface ICalculadoraFinanceira
    {
        ITaxaJuros BancoCentral { get; }
        Task<decimal> CalcularJurosCompostoAsync(decimal valorInicial, int meses);
    }
}