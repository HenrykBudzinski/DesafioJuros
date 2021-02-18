using System.Threading.Tasks;

namespace FinanceiroCore.RecursosExternos.Interfaces
{
    public interface ITaxaJuros
    {
        Task<decimal> GetTaxaJurosAsync();
    }
}