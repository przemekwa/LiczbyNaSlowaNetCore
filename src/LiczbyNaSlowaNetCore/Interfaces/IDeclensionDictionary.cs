// Copyright (c) 2016 Przemek Walkowski

namespace LiczbyNaSlowaNetCore.Interfaces
{
    using System.Collections.Generic;

    public interface IDeclensionDictionary
    {
        List<string> Unity { get; }
        List<string> OthersTens { get; }
        List<string> Tens { get; }
        List<string> Hundreds { get; }
        string[,] Endings { get; }
        List<string> Sign { get; }
        string[,] Current { get; }
        bool HasStems { get; }
    }
}
