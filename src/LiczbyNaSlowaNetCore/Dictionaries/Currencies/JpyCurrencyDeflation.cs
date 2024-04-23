namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class JpyCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.JPY;
        public override string[,] Phases => new[,] 
        { 
            { string.Empty, string.Empty, string.Empty },
            { "jen", "jeny", "jenów" },
            { string.Empty, string.Empty, string.Empty }
        };
    }
}
