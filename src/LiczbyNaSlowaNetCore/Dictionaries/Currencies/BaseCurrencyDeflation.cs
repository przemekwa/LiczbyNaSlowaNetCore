using LiczbyNaSlowaNetCore.Interfaces;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public abstract class BaseCurrencyDeflation : ICurrencyDeflation
    {
        public abstract Currency CurrencyCode { get; }

        protected readonly string[,] withStemsPhrases;

        protected BaseCurrencyDeflation(string[,] withStemsPhrases)
        {
            this.withStemsPhrases = withStemsPhrases;
        }

        public virtual string GetDeflationPhrase( DeflationPhraseType phraseType, int grammarForm) => withStemsPhrases[(int)phraseType, grammarForm];

    }
}
