using LiczbyNaSlowaNETCore;
using LiczbyNaSlowaNETCore.Dictionaries;

namespace LiczbyNaSlowaNETCoreTests.PolishStemsDictionary
{
    public class TestBase
    {
        protected NumberToTextOptions PolishDictionaryWithStemsOptions => new()
        {
            Dictionary = new PolishDictionary(),
            Currency = Currency.NONE,
            Stems = true
        };

        protected NumberToTextOptions PolishDictionaryWithoutStemsOptions => new()
        {
            Dictionary = new PolishDictionary(),
            Currency = Currency.NONE,
            Stems = false
        };
    }
}
