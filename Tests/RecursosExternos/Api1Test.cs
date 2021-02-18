using FinanceiroCore.RecursosExternos.Interfaces;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Tests.RecursosExternos
{
    [Collection(Collections.Api1)]
    public class Api1Test : IClassFixture<Api1Fixture>
    {
        private Api1Fixture _fixture;

        public Api1Test(Api1Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Api1_GetTaxaJuros_Successful()
        {
            var juros = _fixture.BancoCentral.GetTaxaJurosAsync().Result;
            juros.Should().Be(0.01m);
        }
    }
}