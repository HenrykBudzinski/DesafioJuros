namespace Api2.Routes
{
    public static class ApiRoutes
    {
        public static class Financeiro
        {
            public static class Get
            {
                public const string CalcularJuros = "/calculaJuros";
            }
        }

        public static class Github
        {
            public static class Get
            {
                public const string ShowTheCode = "/showmethecode";
            }
        }
    }
}