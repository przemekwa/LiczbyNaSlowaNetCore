
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;

namespace LiczbyNaSlowaNetCore.Interfaces
{
    public interface INumberToTextOptions
    {
        Currency Currency { get; set; }
        IDeclensionDictionary Dictionary { get; set; }
        string SplitDecimal { get; set; }
        bool Stems { get; set; }
    }
}