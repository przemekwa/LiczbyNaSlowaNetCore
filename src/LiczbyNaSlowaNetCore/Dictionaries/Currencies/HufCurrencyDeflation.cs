namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class HufCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.HUF;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "forint", "forinty", "forintów" },
            { string.Empty, string.Empty, string.Empty }
        };
    }
}
