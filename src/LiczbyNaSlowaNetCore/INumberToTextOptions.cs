
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore
{
    public interface INumberToTextOptions
    {
        public Currency Currency { get; set; }
        public Dictionaries.ICurrencyDictionary Dictionary { get; set; }
        public string SplitDecimal { get; set; }
        public bool Stems { get; set; }
    }
}