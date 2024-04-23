// Copyright (c) 2016 Przemek Walkowski

namespace LiczbyNaSlowaNetCore.Interfaces
{
    using System.Collections.Generic;

    public interface IDeclensionDictionary
    {
        List<string> Units { get; }
        List<string> AboveTen { get; }
        List<string> Tens { get; }
        List<string> Hundreds { get; }
        string[,] Endings { get; }
        List<string> Sign { get; }
        string[,] Current { get; }
        bool HasStems { get; }
    }
}
