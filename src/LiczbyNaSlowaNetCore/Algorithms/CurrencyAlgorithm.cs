
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Algorithms
{
    using LiczbyNaSlowaNetCore.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal sealed class CurrencyAlgorithm : Algorithm
    {
        public CurrencyAlgorithm(
            ICurrencyDictionary dictionary,
            ICurrencyDeflation currencyDeflation,
            string splitDecimal,
            bool stems
            )
            : base(dictionary,
                  currencyDeflation,
                  splitDecimal,
                  stems
                  ) { }

        private readonly StringBuilder result = new StringBuilder();
       
        private readonly long[] tempGrammarForm = { 2, 3, 4 };

        public override string Build(IEnumerable<long> numbers)
        {
            var currentPhase = DeflationPhraseType.BeforeComma;

            foreach (var number in numbers)
            {
                var partialResult = new StringBuilder();
                if (number == 0)
                {
                    partialResult.Append(Dictionary.Unity[10]);
                    partialResult.Append(" ");
                    partialResult.Append(CurrencyDeflation.GetDeflationPhrase( currentPhase, 2, WithStems ));
                    result.Append(partialResult.ToString().Trim());
                    result.Append(" ");
                    currentPhase = DeflationPhraseType.AfterComma;
                    continue;
                }

                if (number < 0)
                {
                    partialResult.Append(Dictionary.Sign[2]);
                }

                long tempNumber = number;

                int order = 0;
                int hundreds = 0, tens = 0, unity = 0, othersTens = 0, sumAboveUnity = 0;

                while (tempNumber != 0)
                {
                    // possible overflow exception
                    hundreds = (int)( ( tempNumber % 1000 ) / 100 );
                    tens = (int)( ( tempNumber % 100 ) / 10 );
                    unity = (int)( tempNumber % 10 );
                    othersTens = 0;

                    if ( tens == 1 && unity > 0)
                    {
                        othersTens = unity;
                        tens = 0;
                        unity = 0;
                    }
                    else
                    {
                        othersTens = 0;
                    }

                    sumAboveUnity = hundreds + tens + othersTens;
                    var grammarForm = this.GetGrammarForm( unity, sumAboveUnity );
                    

                    if ((unity + sumAboveUnity) > 0)
                    {
                        var tempPartialResult = partialResult.ToString().Trim();

                        partialResult.Clear();
                        var properUnity = Dictionary.Unity;

                        if (currentPhase == DeflationPhraseType.AfterComma && CurrencyDeflation is ICurrencyNotMaleDeflectionAfterComma && tens == 0)
                        {
                            properUnity = ( CurrencyDeflation as ICurrencyNotMaleDeflectionAfterComma ).GetAfterCommaUnity( WithStems );
                        }

                        if (currentPhase == DeflationPhraseType.BeforeComma && CurrencyDeflation is ICurrencyNotMaleDeflectionBeforeComma)
                        {
                            properUnity = ( CurrencyDeflation as ICurrencyNotMaleDeflectionBeforeComma ).GetBeforeCommaUnity( WithStems );
                        }

                        partialResult.AppendFormat( "{0}{1}{2}{3}{4}{5}",
                            this.SetSpaceBeforeString( Dictionary.Hundreds[ hundreds ] ),
                            this.SetSpaceBeforeString( Dictionary.Tens[ tens ] ),
                            this.SetSpaceBeforeString( Dictionary.OthersTens[ othersTens ] ),
                            this.SetSpaceBeforeString( properUnity[ unity ] ),
                            this.SetSpaceBeforeString( Dictionary.Endings[ order, grammarForm ] ),
                            this.SetSpaceBeforeString( tempPartialResult ) );
                    }

                    order += 1;

                    tempNumber = tempNumber / 1000;
                }

                // hm we are using here some variables (unity, tens, sumabove) that are modified inside above while loop and only there
                // and yet we are using them here, outside loop. It would be better if we could use them only inside while loop...
                partialResult.Append( this.SetSpaceBeforeString(
                    CurrencyDeflation.GetDeflationPhrase( currentPhase, GetCurrencyForm( number, othersTens ), WithStems ) ) );

                result.Append(partialResult.ToString().Trim());

                result.Append(" ");

                if (currentPhase == DeflationPhraseType.BeforeComma && !string.IsNullOrEmpty( SplitDecimal ))
                {
                    result.Append(SplitDecimal);
                    result.Append(" ");
                }

                currentPhase = DeflationPhraseType.AfterComma;
            }

            var finalResult = WithStems ? result.ToString() : RemoveStems(result.ToString());
            return finalResult.Trim();
        }

        private string RemoveStems(string input)
        {
            return input.Replace('ą', 'a')
                .Replace('ę', 'e')
                .Replace('ó', 'o')
                .Replace('ł', 'l')
                .Replace('ć', 'c')
                .Replace('ń', 'n')
                .Replace('ś', 's')
                .Replace('ż', 'z')
                .Replace('ź', 'z');
        }

        private int GetCurrencyForm(long number, int othersTens)
        {
            var hundreds = ( number % 1000 ) / 100;
            var tens = ( number % 100 ) / 10;
            var unity = number % 10;

            if( unity == 1 && (hundreds + tens + othersTens == 0) )
            {
                return 0;
            }

            if (tempGrammarForm.Contains(unity) && tens != 1)
            {
                return 1;
            }

            return 2;
        }

        private int GetGrammarForm(int unity, int sumAboveUnity)
        {
            if ( unity == 1 && sumAboveUnity == 0)
                return  0;

            if (tempGrammarForm.Contains( unity ) )
                return 1;

            return 2;
        }
    }
}
