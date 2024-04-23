namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class LtlCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.LTL;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "lit litewski", "lity litewskie", "litów litewskich" },
            { "cent", "centy", "centów" }
        };
    }
}
