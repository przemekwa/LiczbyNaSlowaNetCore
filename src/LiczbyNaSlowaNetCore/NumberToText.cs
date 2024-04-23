// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore
{
    using System;
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
        public static string Convert(int number, Currency currency = Currency.NONE, bool stems = false)
        {
            return CommonConvert(Math.Sign(number), number, null, new NumberToTextOptions
            {
                Stems = stems,
                Currency = currency,
            });
        } 

        public static string Convert(long number, Currency currency = Currency.NONE, bool stems = false)
        {
            return CommonConvert(Math.Sign(number), number, null, new NumberToTextOptions
            {
                Stems = stems,
                Currency = currency,
            });
        }

        public static string Convert(decimal number, Currency currency = Currency.NONE, bool stems = false)
        {
            var (beforeComma, afterComma) = SplitDecimalToNumbersBeforeAndAfterPoint(number, currency);
            return CommonConvert(Math.Sign(number), beforeComma, afterComma, new NumberToTextOptions
            {
                Stems= stems,
                Currency = currency,
            });
        }

        public static string Convert(int number, NumberToTextOptions options) => CommonConvert(Math.Sign(number), number, null, options);
        public static string Convert(long number, NumberToTextOptions options) => CommonConvert(Math.Sign(number), number, null, options);
        public static string Convert(decimal number, NumberToTextOptions options)
        {
            var (beforeComma, afterComma) = SplitDecimalToNumbersBeforeAndAfterPoint(number, options.Currency);
            return CommonConvert(Math.Sign(number), beforeComma, afterComma, options);
        } 

        private static string CommonConvert(int sign, long? beforeComma, long? afterComma, NumberToTextOptions options)
        {
            var dictionary = options.Dictionary ?? new PolishDictionary();
            var currencyDeflation = CurrencyDeflationFactory.GetCurrencyDeflation(options.Currency);
            var algorithm = new CurrencyAlgorithm(dictionary, currencyDeflation, options.SplitDecimal, options.Stems);

            return algorithm.Build(sign, 
                beforeComma is null ? null : (long?) Math.Abs(beforeComma.Value),
                afterComma is null ? null : (long?)Math.Abs(afterComma.Value));
        }

        /// <summary>
        /// Splits decimal number to number before comma and after comma if it is different than 0
        /// </summary>
        /// <param name="number">If number is greater than long.MaxValue it returns empty array</param>
        /// <returns>Array of up to 2 long numbers</returns>
        private static (long?, long?) SplitDecimalToNumbersBeforeAndAfterPoint(decimal number, Currency currency)
        {
            // eg. 2519203.519203
            // will result in
            // [0] = 2519203
            // [1] = 52 (rounding)
            if (number > long.MaxValue)
                return (null, null);

            
            var roundedNumber = Math.Round(number, 2);
            var beforeComma = (long) Math.Truncate(roundedNumber);
            var afterComma = (long) Math.Abs((beforeComma - roundedNumber) * 100);

            return currency == Currency.NONE && afterComma == 0 ? (beforeComma, null as long?) : (beforeComma, afterComma); 
        }
    }
}
