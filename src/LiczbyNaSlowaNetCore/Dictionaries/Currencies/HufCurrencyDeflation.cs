namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class HufCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.HUF;

        public HufCurrencyDeflation()
            : base(
                new[ , ]
                {
                    { "", "", "" },
                    { "forint", "forinty", "forintów" },
                    { "", "", "" }
                })
        {
        }
    }
}
