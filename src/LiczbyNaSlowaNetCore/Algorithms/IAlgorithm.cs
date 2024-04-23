
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Algorithms
{
    internal interface IAlgorithm
    {
        string Build(int sign, long? beforeComma, long? afterComma);
    }
}
