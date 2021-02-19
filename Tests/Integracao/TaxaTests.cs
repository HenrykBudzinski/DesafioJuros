using System.Globalization;
using System.Net;
using Api1.Routes;
using FluentAssertions;
using Xunit;

namespace Tests.Integracao
{
    [Collection(Collections.Api1)]
    public class TaxaTests : IClassFixture<Api1WebAppFixture>
    {
        private Api1WebAppFixture _fixture;

        public TaxaTests(Api1WebAppFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Fact]
        public async void TaxaJuros_Successful()
        {
            using var request = await _fixture.TestClient.GetAsync(
                ApiRoutes.Taxa.Get.TaxaJuros);

            request.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var response = await request.Content.ReadAsStringAsync();
            response.Should().NotBeNull().And.NotBeEmpty();
            decimal.TryParse(response,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out var juros)
                .Should().BeTrue();
            juros.Should().Be(0.01m);
        }
    }
}