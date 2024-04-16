using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class PercentageDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionAfterComma
    {
        public override Currency CurrencyCode => Currency.PERCENT;
        public override string[,] Phases => new[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "procent", "procenty", "procent" },
            { "setna procenta", "setne procenta", "setnych procenta" }
        };

        public List<string> GetAfterCommaUnity()
            => new List<string> { string.Empty, "jedna", "dwie", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
    }
}