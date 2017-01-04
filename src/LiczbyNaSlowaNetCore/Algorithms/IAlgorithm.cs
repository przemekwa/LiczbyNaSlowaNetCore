
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Algorithms
{
    using System.Collections.Generic;

    using Dictionaries;

    internal interface IAlgorithm
    {
        string Build( IEnumerable<long> numbers );
    }
}
