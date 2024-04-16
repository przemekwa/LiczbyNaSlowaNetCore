namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class PlnCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.PLN;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "złoty", "złote", "złotych" },
            { "grosz", "grosze", "groszy" }
        };
    }
}