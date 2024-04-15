
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Algorithms
{
    using System.Collections.Generic;

    internal interface IAlgorithm
    {
        string Build(IEnumerable<long> numbers);
    }
}
