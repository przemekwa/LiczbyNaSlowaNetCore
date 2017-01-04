using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiczbyNaSlowaNETCore;
using LiczbyNaSlowaNETCore.Dictionaries;
using LiczbyNaSlowaNETCore.Dictionaries.Currencies;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public abstract class TestBase
    {
        protected NumberToTextOptions NumberToTextOptions { get; set; } = new NumberToTextOptions
        {
            Dictionary = new PolishWithsStemsDictionary(),
            Currency = Currency.NONE
        };
    }
}
