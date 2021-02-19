using FinanceiroCore.Comum;
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
            //  Arrange
            var bancoCentral = Substitute.For<ITaxaJuros>();
            bancoCentral.GetTaxaJurosAsync().Returns(0.01m);
            var calculadora = new Calculadora(bancoCentral);

            //  Assert
            calculadora.CalcularJurosCompostoAsync(100m, 5)
                .Result.Should().Be(105.10m);
        }
    }
}