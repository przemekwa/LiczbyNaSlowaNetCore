using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public abstract class BaseCurrencyDeflation : ICurrencyDeflation
    {
        public abstract Currency CurrencyCode { get; }
        public abstract string[,] Phases { get; }
        public virtual string GetDeflationPhrase(DeflationPhraseType phraseType, int grammarForm) => Phases[(int)phraseType, grammarForm];

    }
}
