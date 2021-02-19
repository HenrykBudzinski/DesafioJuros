using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Integracao
{
    public class Api2WebAppFixture : IDisposable
    {
        public readonly HttpClient TestClient;
        
        public Api2WebAppFixture()
        {
            var appFactory = new WebApplicationFactory<Api2.Startup>();
            TestClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
            TestClient?.Dispose();
        }
    }
}