
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore
{
    using Dictionaries;

    public class NumberToTextOptions : INumberToTextOptions
    {
        public Currency Currency { get; set; }

        public ICurrencyDictionary Dictionary { get; set; }

        public string SplitDecimal { get; set; } = string.Empty;

        public bool Stems { get; set; }
    }
}