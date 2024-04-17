// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class Trilions : TestBase
    {
        [Fact]
        public void Test_1_000_000_000_000_000_000()
        {
            Assert.Equal("jeden trylion", NumberToText.Convert(1_000_000_000_000_000_000, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_2_000_000_000_000_000_006()
        {
            Assert.Equal("dwa tryliony sześć", NumberToText.Convert(2_000_000_000_000_000_006, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_9_000_000_000_012_000_256()
        {
            Assert.Equal("dziewięć trylionów dwanaście milionów dwieście pięćdziesiąt sześć", NumberToText.Convert(9_000_000_000_012_000_256, PolishDictionaryWithStemsOptions));
        }
    }
}
