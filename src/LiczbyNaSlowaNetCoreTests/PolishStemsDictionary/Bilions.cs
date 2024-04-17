
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class Bilions : TestBase
    {
        [Fact]
        public void Test_1_000_000_000_000()
        {
            Assert.Equal("jeden bilion", NumberToText.Convert(1_000_000_000_000, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_2_000_000_000_000()
        {
            Assert.Equal("dwa biliony", NumberToText.Convert(2_000_000_000_000, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_2_000_000_000_006()
        {
            Assert.Equal("dwa biliony sześć", NumberToText.Convert(2_000_000_000_006, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_5_000_012_000_256()
        {
            Assert.Equal("pięć bilionów dwanaście milionów dwieście pięćdziesiąt sześć", NumberToText.Convert(5_000_012_000_256, PolishDictionaryWithStemsOptions));
        }
    }
}
