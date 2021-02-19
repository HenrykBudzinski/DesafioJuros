using System.Globalization;
using System.Net;
using Api2.Routes;
using FluentAssertions;
using Xunit;

namespace Tests.Integracao
{
    [Collection(Collections.Api2)]
    public class FinanceiroTests : IClassFixture<Api2WebAppFixture>
    {
        private Api2WebAppFixture _fixture;

        public FinanceiroTests(Api2WebAppFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void CalculaJuros_Successful()
        {
            using var request = await _fixture.TestClient.GetAsync(
                ApiRoutes.Financeiro.Get.CalcularJuros + $"?valorinicial=100.0&meses=5");
            
            request.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var response = await request.Content.ReadAsStringAsync();
            response.Should()
                .NotBeNull()
                .And.NotBeEmpty();
            decimal.TryParse(response,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out var valorTotal)
                .Should().BeTrue();
            valorTotal.Should().Be(105.1m);
        }
        
        [Fact]
        public async void CalculaJuros_InformandoNumeroNegativoNoParametroMeses_BadRequestException()
        {
            using var request = await _fixture.TestClient.GetAsync(
                ApiRoutes.Financeiro.Get.CalcularJuros + $"?valorinicial=100.0&meses=-1");
            
            request.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}