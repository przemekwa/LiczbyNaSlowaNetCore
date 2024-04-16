using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class SekCurrencyDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionBeforeComma
    {
        public override Currency CurrencyCode => Currency.SEK;

        public SekCurrencyDeflation()
            : base(
                  new[,]
                    {
                        { "", "", "" },
                        { "korona szwedzka", "korony szwedzkie", "koron szwedzkich" },
                        { "øre", "øre", "øre" }
                    })
        {
        }

        public List<string> GetBeforeCommaUnity()
            => new List<string> { "", "jedna", "dwie", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
    }
}