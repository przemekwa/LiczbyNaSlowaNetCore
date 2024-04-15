
// Copyright (c) 2014 Przemek Walkowski

using System;

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    
    public class Billions : TestBase
    {

       [Fact]
        public void Test_2000000000()
        {
            Assert.Equal("dwa miliardy", NumberToText.Convert(2000000000, PolishDictionaryWithStemsOptions));
        }

       [Fact]
        public void Test_2000000006()
        {
            Assert.Equal("dwa miliardy sześć", NumberToText.Convert(2000000006, PolishDictionaryWithStemsOptions));
        }

       [Fact]
        public void Test_2000000056()
        {
            Assert.Equal("dwa miliardy pięćdziesiąt sześć", NumberToText.Convert(2000000056, PolishDictionaryWithStemsOptions));
        }

       [Fact]
        public void Test_2000000206()
        {
            Assert.Equal("dwa miliardy dwieście sześć", NumberToText.Convert(2000000206, PolishDictionaryWithStemsOptions));
        }
    }
}
