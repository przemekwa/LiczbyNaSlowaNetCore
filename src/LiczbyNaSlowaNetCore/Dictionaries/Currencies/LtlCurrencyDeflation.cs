using System.Collections.Generic;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class LtlCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.LTL;

        public LtlCurrencyDeflation()
            : base( new[ , ]
                   {
                    {"", "", ""},
                    {"lit litewski", "lity litewskie", "litow litewskich"},
                    {"cent", "centy", "centow"}
                },
                new[ , ]
                    {
                    {"", "", ""},
                    {"lit litewski", "lity litewskie", "litów litewskich"},
                    {"cent", "centy", "centów"}
                } )
        {

        }
    }
}
