using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class NokCurrencyDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionBeforeComma
    {
        public override Currency CurrencyCode => Currency.NOK;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty},
            { "korona norweska", "korony norweskie", "koron norweskich" },
            { "øre", "øre", "øre" }
        };

        public List<string> GetBeforeCommaUnity()
            => new List<string> { string.Empty, "jedna", "dwie", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
    }
}