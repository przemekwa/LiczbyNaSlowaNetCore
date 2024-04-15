using LiczbyNaSlowaNETCore;
using LiczbyNaSlowaNETCore.Dictionaries;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class TestBase
    {
        protected NumberToTextOptions PolishDictionaryWithStemsOptions { get; set; } = new NumberToTextOptions
        {
            Dictionary = new PolishWithsStemsDictionary(),
            Currency = Currency.NONE,
            Stems = true
        };
    }
}
