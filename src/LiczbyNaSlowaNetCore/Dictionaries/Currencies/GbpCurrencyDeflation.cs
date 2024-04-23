namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class GbpCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.GBP;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "funt brytyjski", "funty brytyjskie", "funtów brytyjskich" },
            { "pens", "pensy", "pensów" }
        };
    }
}
