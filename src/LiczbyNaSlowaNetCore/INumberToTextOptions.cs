
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore.Dictionaries;

namespace LiczbyNaSlowaNETCore
{
    public interface INumberToTextOptions
    {
        public Currency Currency { get; set; }
        public ICurrencyDictionary Dictionary { get; set; }
        public string SplitDecimal { get; set; }
        public bool Stems { get; set; }
    }
}