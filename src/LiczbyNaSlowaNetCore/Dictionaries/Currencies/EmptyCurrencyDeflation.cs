namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class EmptyCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.NONE;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { string.Empty, string.Empty, string.Empty },
            { string.Empty, string.Empty, string.Empty }
        };
    }
}