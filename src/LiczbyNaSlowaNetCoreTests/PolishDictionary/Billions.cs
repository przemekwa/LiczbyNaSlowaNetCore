
// Copyright (c) 2014 Przemek Walkowski

using LiczbyNaSlowaNETCore;
using Xunit;

namespace LiczbyNaSlowaNETCoreTests
{
    public class Billions
    {
        [Fact]
        public void Test_2000000000()
        {
            Assert.Equal("dwa miliardy", NumberToText.Convert(2_000_000_000));
        }

        [Fact]
        public void Test_2000000006()
        {
            Assert.Equal("dwa miliardy szesc", NumberToText.Convert(2_000_000_006));
        }

        [Fact]
        public void Test_2000000056()
        {
            Assert.Equal("dwa miliardy piecdziesiat szesc", NumberToText.Convert(2_000_000_056));
        }

        [Fact]
        public void Test_2000000206()
        {
            Assert.Equal("dwa miliardy dwiescie szesc", NumberToText.Convert(2_000_000_206));
        }
    }
}
