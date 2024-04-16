using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class NokCurrencyDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionBeforeComma
    {
        public override Currency CurrencyCode => Currency.NOK;

        public NokCurrencyDeflation()
            : base(
                new[ , ]
                {
                    { "", "", ""},
                    { "korona norweska", "korony norweskie", "koron norweskich" },
                    { "øre", "øre", "øre" }
                })
        {
        }

        public List<string> GetBeforeCommaUnity()
            => new List<string> { "", "jedna", "dwie", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
    }
}