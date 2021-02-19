using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Integracao
{
    public class Api1WebAppFixture : IDisposable
    {
        public readonly HttpClient TestClient;
        
        public Api1WebAppFixture()
        {
            var appFactory = new WebApplicationFactory<Api1.Startup>();
            TestClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
            TestClient?.Dispose();
        }
    }
}