using System;
using FinanceiroCore.Comum.Interfaces;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Tests.Core
{
    [Collection(Collections.Isolados)]
    public class FinanceiroCoreTests
    {
        [Fact]
        public void Utils_CalcularJurosComposto_Successful()
        {
            var valorEsperado = 105.10m;
            var calculadora = Substitute.For<ICalculadoraFinanceira>();
            calculadora.CalcularJurosCompostoAsync(100m, 5).Returns(valorEsperado);

            calculadora.CalcularJurosCompostoAsync(100m, 5).Result
                .Should().Be(valorEsperado);
        }
    }
}