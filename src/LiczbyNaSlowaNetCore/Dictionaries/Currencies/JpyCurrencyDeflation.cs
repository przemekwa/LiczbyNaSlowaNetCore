namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class JpyCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.JPY;

        public JpyCurrencyDeflation()
            : base(
                new[ , ]
                {
                    { "", "", "" },
                    { "jen", "jeny", "jenów" },
                    { "", "", "" }
                })
        {
        }
    }
}
