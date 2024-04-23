namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class UsdCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.USD;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "dolar", "dolary", "dolarów" },
            { "cent", "centy", "centów" }
        };
    }
}