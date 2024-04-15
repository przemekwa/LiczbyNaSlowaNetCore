using LiczbyNaSlowaNETCore;
using LiczbyNaSlowaNETCore.Dictionaries;

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
