
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Algorithms
{
    using LiczbyNaSlowaNetCore.Interfaces;
    using System.Linq;
    using System.Text;

    internal sealed class CurrencyAlgorithm : Algorithm
    {
        public CurrencyAlgorithm(
            IDeclensionDictionary dictionary,
            ICurrencyDeflation currencyDeflation,
            string splitDecimal,
            bool stems
            )
            : base(dictionary,
                  currencyDeflation,
                  splitDecimal,
                  stems
                  ) { }

        private readonly long[] tempGrammarForm = { 2, 3, 4 };

        public override string Build(long? beforeComma, long? afterComma)
        {
            // sign?
            var beforeCommaText = beforeComma.HasValue ? GetNumberToTextBeforeComma(beforeComma.Value) : string.Empty;
            var afterCommaText = afterComma.HasValue ? GetNumberToTextAfterComma(afterComma.Value) : string.Empty;

            var splitDecimal = string.IsNullOrWhiteSpace(SplitDecimal) ? string.Empty : " " + SplitDecimal;
            var result = $"{beforeCommaText}{splitDecimal} {afterCommaText}";
            var finalResult = WithStems ? result.ToString() : RemoveStems(result);
            return finalResult.Trim();
        }

        private string GetNumberToTextBeforeComma(long number)
        {
            var partialResult = new StringBuilder();

            if (number < 0)
                partialResult.Append(Dictionary.Sign[1]);

            if (number == 0)
            {
                partialResult.Append(Dictionary.Units[10]);
                partialResult.Append(" ");
                partialResult.Append(CurrencyDeflation.GetDeflationPhrase(DeflationPhraseType.BeforeComma, 2));
                return partialResult.ToString().Trim();
            }

            string grindedNumber = GrindNumber(DeflationPhraseType.BeforeComma, number);
            partialResult.Append(grindedNumber);

            // hm we are using here some variables (unity, tens, sumabove) that are modified inside above while loop and only there
            // and yet we are using them here, outside loop. It would be better if we could use them only inside while loop...
            partialResult.Append(SetSpaceBeforeString(
                CurrencyDeflation.GetDeflationPhrase(DeflationPhraseType.BeforeComma, GetCurrencyForm(number))));

            var result = partialResult.ToString().Trim();

            return result;
        }

        /// <summary>
        /// Limited from 0 to 99 because of Math.Round(x, 2) in NumberToText class
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetNumberToTextAfterComma(long number)
        {
            var partialResult = new StringBuilder();
            if (number == 0)
            {
                partialResult.Append(Dictionary.Units[10]);
                partialResult.Append(" ");
                partialResult.Append(CurrencyDeflation.GetDeflationPhrase(DeflationPhraseType.AfterComma, 2));
                return partialResult.ToString().Trim();
            }

            // should be before all number to text
            if (number < 0)
            {
                partialResult.Append(Dictionary.Sign[2]);
            }

            string grindedNumber = GrindNumber(DeflationPhraseType.AfterComma, number);
            partialResult.Append(grindedNumber);

            // hm we are using here some variables (unity, tens, sumabove) that are modified inside above while loop and only there
            // and yet we are using them here, outside loop. It would be better if we could use them only inside while loop...
            partialResult.Append(SetSpaceBeforeString(
                CurrencyDeflation.GetDeflationPhrase(DeflationPhraseType.AfterComma, GetCurrencyForm(number))));

            return partialResult.ToString().Trim();
        }

        private string GrindNumber(DeflationPhraseType currentPhase, long number)
        {
            var partialResult = new StringBuilder();
            long tempNumber = number;

            int order = 0;

            while (tempNumber != 0)
            {
                int hundreds = (int) ((tempNumber % 1000) / 100);
                int tens = (int) ((tempNumber % 100) / 10);
                int unity = (int) (tempNumber % 10);
                int othersTens;

                if (tens == 1 && unity > 0)
                {
                    othersTens = unity;
                    tens = 0;
                    unity = 0;
                }
                else
                {
                    othersTens = 0;
                }

                int sumAboveUnity = hundreds + tens + othersTens;
                var grammarForm = GetGrammarForm(unity, sumAboveUnity);

                if ((unity + sumAboveUnity) > 0)
                {
                    var tempPartialResult = partialResult.ToString().Trim();

                    partialResult.Clear();
                    var properUnity = Dictionary.Units;

                    if (currentPhase == DeflationPhraseType.AfterComma && CurrencyDeflation is ICurrencyNotMaleDeflectionAfterComma && tens == 0)
                    {
                        properUnity = (CurrencyDeflation as ICurrencyNotMaleDeflectionAfterComma).GetAfterCommaUnity();
                    }

                    if (currentPhase == DeflationPhraseType.BeforeComma && CurrencyDeflation is ICurrencyNotMaleDeflectionBeforeComma)
                    {
                        properUnity = (CurrencyDeflation as ICurrencyNotMaleDeflectionBeforeComma).GetBeforeCommaUnity();
                    }

                    partialResult.AppendFormat("{0}{1}{2}{3}{4}{5}",
                        SetSpaceBeforeString(Dictionary.Hundreds[hundreds]),
                        SetSpaceBeforeString(Dictionary.Tens[tens]),
                        SetSpaceBeforeString(Dictionary.AboveTen[othersTens]),
                        SetSpaceBeforeString(properUnity[unity]),
                        SetSpaceBeforeString(Dictionary.Endings[order, grammarForm]),
                        SetSpaceBeforeString(tempPartialResult));
                }

                order += 1;

                tempNumber = tempNumber / 1000;
            }

            return partialResult.ToString().Trim();
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

        private int GetCurrencyForm(long number)
        {
            var hundreds = (number % 1000) / 100;
            var tens = (number % 100) / 10;
            var unity = number % 10;

            // np. jeden milion
            if( unity == 1 && (hundreds + tens == 0) )
            {
                return 0;
            }

            // np. dwa/trzy/cztery miliony
            if (tempGrammarForm.Contains(unity) && tens != 1)
            {
                return 1;
            }

            // np. dwanaście milionów 
            return 2;
        }

        private int GetGrammarForm(int unity, int sumAboveUnity)
        {
            // np. jeden tysiąc
            if (unity == 1 && sumAboveUnity == 0)
                return  0;

            if (tempGrammarForm.Contains( unity ) )
                return 1;

            return 2;
        }
    }
}
