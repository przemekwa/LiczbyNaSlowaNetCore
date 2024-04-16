using System;
using System.Collections.Generic;
using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public static class CurrencyDeflationFactory
    {
        static CurrencyDeflationFactory()
        {
            // maybe go over all types that implement ICurrencyDeflation in current assembly?
            CurrencyDeflationList = new List<ICurrencyDeflation>
            {
                new PlnCurrencyDeflation(),
                new ChfCurrencyDeflation(),
                new CzkCurrenctDeflation(),
                new EmptyCurrencyDeflation(),
                new EurCurrencyDeflation(),
                new GbpCurrencyDeflation(),
                new HufCurrencyDeflation(),
                new JpyCurrencyDeflation(),
                new LtlCurrencyDeflation(),
                new NokCurrencyDeflation(),
                new LtlCurrencyDeflation(),
                new PercentageDeflation(),
                new UsdCurrencyDeflation(),
                new SekCurrencyDeflation(),
            };
        }

        public static List<ICurrencyDeflation> CurrencyDeflationList { get; }

        public static ICurrencyDeflation GetCurrencyDeflation(Currency currency)
        {
            var currencyInstance = CurrencyDeflationList.Find( x => x.CurrencyCode == currency)
                ?? throw new NotImplementedException($"No currency deflation is defined for currency {currency}");

            return currencyInstance;
        }
 
    }
}