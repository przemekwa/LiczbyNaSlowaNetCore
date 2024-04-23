using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class SekCurrencyDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionBeforeComma
    {
        public override Currency CurrencyCode => Currency.SEK;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "korona szwedzka", "korony szwedzkie", "koron szwedzkich" },
            { "øre", "øre", "øre" }
        };

        public List<string> GetBeforeCommaUnity()
            => new List<string> { string.Empty, "jedna", "dwie", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
    }
}