using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public class CzkCurrenctDeflation : BaseCurrencyDeflation, ICurrencyNotMaleDeflectionBeforeComma
    {
        public override Currency CurrencyCode => Currency.CZK;

        public CzkCurrenctDeflation()
            : base(
                    new[ , ]
                    {
                        {"", "", ""},
                        {"korona czeska", "korony czeskie", "koron czeskich"},
                        {"halerz", "halerze", "halerzy"}
                    },
                    new[ , ]
                    {
                        {"", "", ""},
                        {"korona czeska", "korony czeskie", "koron czeskich"},
                        {"halerz", "halerze", "halerzy"}
                    } )
        {

        }

        public List<string> GetBeforeCommaUnity( bool withStems )
        {
            if( withStems )
            {
                return new List<string>
                {
                    "","jedna","dwie" , "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć","zero"
                };
            }
            else
            {
                return new List<string>
                {
                    "","jedna","dwie" , "trzy", "cztery", "piec", "szesc", "siedem", "osiem", "dziewiec","zero"
                };
            }
        }
    }
}
