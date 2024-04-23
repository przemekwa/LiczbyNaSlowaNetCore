
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class Unity : TestBase
    {
        [Fact]
        public void Test_0()
        {
            Assert.Equal("zero", NumberToText.Convert(0));
        }

        [Fact]
        public void Test_3()
        {
            Assert.Equal("trzy", NumberToText.Convert(3));
        }
    }
}
