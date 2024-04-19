
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore
{
    using System;
    using System.Collections.Generic;

    using Algorithms;
    using Dictionaries;
    using Dictionaries.Currencies;

    public static class NumberToText
    {
        /// <summary>
        /// Convert (int) number into words.
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <param name="currency">Currency of number</param>
        /// <param name="stems">Stems</param>
        /// <returns>words that describe the number</returns>
        public static string Convert(int number, Currency currency = Currency.NONE, bool stems = false) => Convert((long)number, currency, stems);

        public static string Convert(long number, Currency currency = Currency.NONE, bool stems = false)
        {
            return CommonConvert(new[] { number }, new NumberToTextOptions
            {
                Stems = stems,
                Currency = currency,
            });
        }

        public static string Convert(decimal number, Currency currency = Currency.NONE, bool stems = false )
        {
            return CommonConvert(SplitNumbers(number, currency), new NumberToTextOptions
            {
                Stems = stems,
                Currency = currency,
            });
        }

        public static string Convert(int number, NumberToTextOptions options) => Convert((long)number, options);
        public static string Convert(long number, NumberToTextOptions options) => CommonConvert(new[] { number }, options);
        public static string Convert(decimal number, NumberToTextOptions options) => CommonConvert(SplitNumbers(number, options.Currency), options);

        private static string CommonConvert(IEnumerable<long> numbers, NumberToTextOptions options)
        {
            var currencyDeflation = CurrencyDeflationFactory.GetCurrencyDeflation(options.Currency);
            var dictionary = options.Dictionary ?? new PolishDictionary();

            var algorithm = new CurrencyAlgorithm(dictionary, currencyDeflation, options.SplitDecimal, options.Stems);
           
            return algorithm.Build(numbers);
        }

        /// <summary>
        /// Splits decimal number to number before comma and after comma if it is different than 0
        /// </summary>
        /// <param name="number">If number is greater than long.MaxValue it returns empty array</param>
        /// <returns>Array of up to 2 long numbers</returns>
        private static IEnumerable<long> SplitNumbers(decimal number, Currency currency)
        {
            // eg. 2519203.519203
            // will result in
            // [0] = 2519203
            // [1] = 52 (rounding)
            if (number > long.MaxValue)
                return Array.Empty<long>();

            var roundedNumber = Math.Round(number, 2);
            var beforeComma = (long) Math.Truncate(roundedNumber);
            var afterComma = (long) Math.Abs((beforeComma - roundedNumber) * 100);

            return currency == Currency.NONE && afterComma == 0 ? new long[] { beforeComma } : new long[] { beforeComma, afterComma }; 
        }
    }
}
