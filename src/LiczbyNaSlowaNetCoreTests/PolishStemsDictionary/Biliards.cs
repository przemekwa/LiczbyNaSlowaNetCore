
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class Billiards : TestBase
    {
        [Fact]
        public void Test_2_000_000_000_000_000()
        {
            Assert.Equal("dwa biliardy", NumberToText.Convert(2_000_000_000_000_000, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_2_000_000_000_000_006()
        {
            Assert.Equal("dwa biliardy sześć", NumberToText.Convert(2_000_000_000_000_006, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_2_000_000_000_000_056()
        {
            Assert.Equal("dwa biliardy pięćdziesiąt sześć", NumberToText.Convert(2_000_000_000_000_056, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_2_000_000_012_000_206()
        {
            Assert.Equal("dwa biliardy dwanaście milionów dwieście sześć", NumberToText.Convert(2_000_000_012_000_206, PolishDictionaryWithStemsOptions));
        }
    }
}
