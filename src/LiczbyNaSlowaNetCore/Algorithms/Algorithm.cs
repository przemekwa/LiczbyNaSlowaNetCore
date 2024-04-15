
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore
{
    using System;
    using System.Collections.Generic;

    using Algorithms;
    using Dictionaries;
    using Dictionaries.Currencies;
    internal abstract class Algorithm : IAlgorithm
    {
        protected readonly ICurrencyDictionary Dictionary;
        protected readonly ICurrencyDeflation CurrencyDeflation;
        protected readonly string SplitDecimal;
        protected readonly bool WithStems;
        
        protected Algorithm(ICurrencyDictionary dictionary, ICurrencyDeflation currencyDeflation, string splitDecimal, bool withStems )
        {
            Dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
            CurrencyDeflation = currencyDeflation ?? throw new ArgumentNullException(nameof(currencyDeflation));
            SplitDecimal = splitDecimal;
            WithStems = withStems;
        }

        public abstract string Build(IEnumerable<long> numbers);

        protected virtual string SetSpaceBeforeString(string @string)
        {
            return string.IsNullOrEmpty(@string) ? string.Empty : " " + @string;
        }
    }
}