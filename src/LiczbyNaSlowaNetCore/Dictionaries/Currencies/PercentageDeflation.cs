using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class PercentageDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionAfterComma
    {
        public override Currency CurrencyCode => Currency.PERCENT;

        public PercentageDeflation()
            : base(
                  new[,]
                  {
                        { "", "", "" },
                        { "procent", "procenty", "procent" },
                        { "setna procenta", "setne procenta", "setnych procenta" }
                  })
        {
        }

        public List<string> GetAfterCommaUnity()
            => new List<string> { "", "jedna", "dwie", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
    }
}