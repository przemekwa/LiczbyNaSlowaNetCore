namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class UsdCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.USD;

        public UsdCurrencyDeflation()
            : base(
                new[,]
                    {
                        { "", "", "" },
                        { "dolar", "dolary", "dolarów" },
                        { "cent", "centy", "centów" }
                })
        {
        }
    }
}