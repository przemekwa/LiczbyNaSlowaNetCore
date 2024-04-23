
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class Tens : TestBase
    {
        [Fact]
        public void Test_11()
        {
            Assert.Equal("jedenaście", NumberToText.Convert(11, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_13()
        {
            Assert.Equal("trzynaście", NumberToText.Convert(13, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_18()
        {
            Assert.Equal("osiemnaście", NumberToText.Convert(18, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_20()
        {
            Assert.Equal("dwadzieścia", NumberToText.Convert(20, PolishDictionaryWithStemsOptions));
        }

        [Fact]
        public void Test_84()
        {
            Assert.Equal("osiemdziesiąt cztery", NumberToText.Convert(84, PolishDictionaryWithStemsOptions));
        }
    }
}
