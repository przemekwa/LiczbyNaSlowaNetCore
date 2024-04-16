namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class PlnCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.PLN;

        public PlnCurrencyDeflation()
            : base(
                new[,]
                {
                    { "", "", "" },
                    { "złoty", "złote", "złotych" },
                    { "grosz", "grosze", "groszy" }
                })
        {
        }
    }
}