using System;
using FinanceiroCore.Comum;
using FinanceiroCore.Comum.Interfaces;
using FinanceiroCore.RecursosExternos.Interfaces;
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
            var bancoCentral = Substitute.For<ITaxaJuros>();
            bancoCentral.GetTaxaJurosAsync().Returns(0.01m);

            var calculadora = new Calculadora(bancoCentral);

            calculadora.CalcularJurosCompostoAsync(100m, 5).Result
                .Should().Be(105.10m);
        }
    }
}