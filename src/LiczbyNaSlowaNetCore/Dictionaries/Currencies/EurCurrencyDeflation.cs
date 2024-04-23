namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class EurCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.EUR;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "euro", "euro", "euro" },
            { "cent", "centy", "centów" }
        };
    }
}