using System;
using System.Net.Http;
using System.Threading.Tasks;
using FinanceiroCore.Comum.Interfaces;
using FinanceiroCore.RecursosExternos;
using FinanceiroCore.RecursosExternos.Interfaces;

namespace FinanceiroCore.Comum
{
    public class Calculadora : ICalculadoraFinanceira
    {
        public ITaxaJuros BancoCentral { get; }

        public Calculadora(ITaxaJuros bc)
        {
            BancoCentral = bc;
        }

        /// <summary>
        /// Aplica um juros composto sobre um valor inicial
        /// </summary>
        /// <param name="valorInicial">Um decimal que representa o valor ao qual o juros será aplicado</param>
        /// <param name="meses">Um número maior ou igual a zero</param>
        /// <returns>O valor corrigido</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        public async Task<decimal> CalcularJurosCompostoAsync(decimal valorInicial, int meses)
        {
            if (valorInicial == 0)
            {
                throw new ArgumentException("Informe um valor diferente de zero", "valorInicial");
            }
            
            if (meses < 0)
            {
                throw new ArgumentException("Informe um valor maior ou igual a zero", "meses");
            }
            var juros = await BancoCentral.GetTaxaJurosAsync();
            var jurosTotal = Math.Pow(1 + (double)juros, meses);
            var valorTotal = valorInicial * (decimal) jurosTotal;
            return Math.Truncate(100m * valorTotal) / 100m;;
        }
    }
}