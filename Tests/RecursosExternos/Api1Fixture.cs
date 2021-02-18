using System;
using FinanceiroCore.RecursosExternos;
using FinanceiroCore.RecursosExternos.Interfaces;

namespace Tests.RecursosExternos
{
    public class Api1Fixture : IDisposable
    {
        public ITaxaJuros BancoCentral { get; private set; }

        public Api1Fixture()
        {
            BancoCentral = new Api1Client(Constantes.Api1Address);
        }

        public void Dispose()
        {
            BancoCentral = null;
        }
    }
}