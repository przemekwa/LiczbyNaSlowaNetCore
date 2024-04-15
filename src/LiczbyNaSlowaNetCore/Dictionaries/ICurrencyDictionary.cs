
// Copyright (c) 2016 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Dictionaries
{
    using System.Collections.Generic;

    public interface ICurrencyDictionary
    {
        List<string> Unity { get; }
        List<string> OthersTens { get; }
        List<string> Tens{ get; }
        List<string> Hundreds{ get; }
        string[,] Endings{ get; }
        List<string> Sign{ get; }
        string[,] Current{ get; }
        bool HasStems { get; }
    }
}
