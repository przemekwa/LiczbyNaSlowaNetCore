using System.Collections.Generic;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class EmptyCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.NONE;

        public EmptyCurrencyDeflation()
            : base(
                  new[ , ]
                    {
                        {"", "", ""},
                        {"", "", ""},
                        {"", "", ""}
                    },
                  new[ , ]
                    {
                        {"", "", ""},
                        {"", "", ""},
                        {"", "", ""}
                    } )
        { 
        }
    }
}