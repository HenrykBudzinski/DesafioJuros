using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FinanceiroCore.RecursosExternos.Interfaces;

namespace FinanceiroCore.RecursosExternos
{
    public class Api1Client : ITaxaJuros
    {
        private readonly Uri _baseUri;

        public Api1Client(string baseUri)
        {
            _baseUri = new Uri(baseUri);
        }
        
        /// <summary>
        /// Busca o valor da taxa de juros de uma api externa (Api1).
        /// </summary>
        /// <returns>O valor da taxa de juros. Se a taxa de juros for de 1% será retornado 0.01.</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<decimal> GetTaxaJurosAsync()
        {
            using var http = new HttpClient
            {
                BaseAddress = _baseUri
            };
            using var response = await http.GetAsync("/taxaJuros");
            response.EnsureSuccessStatusCode();
            var text = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(text) || 
                !decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var taxes))
            {
                throw new HttpRequestException(
                    "A Api1 está informando valores inválidos", 
                    null, 
                    HttpStatusCode.ServiceUnavailable);
            }

            return taxes;
        }
    }
}