
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore
{
    using Algorithms;
    using LiczbyNaSlowaNetCore.Interfaces;
    using System;

    internal abstract class Algorithm : IAlgorithm
    {
        protected readonly IDeclensionDictionary Dictionary;
        protected readonly ICurrencyDeflation CurrencyDeflation;
        protected readonly string SplitDecimal;
        protected readonly bool WithStems;
        
        protected Algorithm(IDeclensionDictionary dictionary, ICurrencyDeflation currencyDeflation, string splitDecimal, bool withStems )
        {
            Dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
            CurrencyDeflation = currencyDeflation ?? throw new ArgumentNullException(nameof(currencyDeflation));
            SplitDecimal = splitDecimal;
            WithStems = withStems;
        }

        public abstract string Build(long? beforeComma, long? afterComma);

        protected virtual string SetSpaceBeforeString(string @string)
        {
            return string.IsNullOrEmpty(@string) ? string.Empty : " " + @string;
        }
    }
}