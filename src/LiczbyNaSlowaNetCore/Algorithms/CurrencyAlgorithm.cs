
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Algorithms
{
    using LiczbyNaSlowaNetCore.Interfaces;
    using System;
    using System.Collections.Generic;
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

        public override string Build(int sign, long? beforeComma, long? afterComma)
        {
            if (beforeComma is null && afterComma is null)
                return string.Empty;

            var signText = sign < 0 ? Dictionary.Sign[1] + " " : string.Empty;
            var beforeCommaText = CanDoBeforeComma(sign, beforeComma) ? " " + GetNumberToText(DeflationPhraseType.BeforeComma, beforeComma.Value) : string.Empty;
            var afterCommaText = afterComma.HasValue ? " " + GetNumberToText(DeflationPhraseType.AfterComma, afterComma.Value) : string.Empty;
            var splitDecimal = " " + SplitDecimal ?? string.Empty;
            
            var result = signText;
            if (!string.IsNullOrWhiteSpace(beforeCommaText))
                result = result.Trim() + beforeCommaText;

            if (!string.IsNullOrWhiteSpace(splitDecimal))
                result = result.Trim() + splitDecimal;

            if (!string.IsNullOrWhiteSpace(afterCommaText))
                result = (string.IsNullOrEmpty(SplitDecimal) ? result.Trim() : result) + afterCommaText;

            return WithStems ? result.Trim() : RemoveStems(result).Trim();
        }

        private bool CanDoBeforeComma(int sign, long? beforeComma)
        {
            //np -0,23 zł = minus dwadzieścia trzy grosze
            if (beforeComma.HasValue && beforeComma == 0 && sign < 0) return false;

            //np. 0,23 zł = zero złotych dwadzieścia trzy grosze
            //np. 5 zł = pięć złotych
            //np. 5,23 zł = pięć złotych dwadzieścia trzy grosze
            //np. -5 zł = minus pięć złotych
            return true;
        }

        private string GetNumberToText(DeflationPhraseType phase, long number)
        {
            if (number == 0)
                return $"{Dictionary.Units[10]} {CurrencyDeflation.GetDeflationPhrase(phase, 2)}".Trim();

            var builder = new StringBuilder();
            long tempNumber = number;

            int order = 0;
            while (tempNumber != 0)
            {
                int hundreds = (int)((tempNumber % 1000) / 100);
                int tens = (int)((tempNumber % 100) / 10);
                int unity = (int)(tempNumber % 10);
                int aboveTens;

                if (tens == 1 && unity > 0)
                {
                    aboveTens = unity;
                    tens = 0;
                    unity = 0;
                }
                else
                {
                    aboveTens = 0;
                }

                int sumAboveUnity = hundreds + tens + aboveTens;
                if ((unity + sumAboveUnity) > 0)
                {
                    var tempPartialResult = builder.ToString().Trim();

                    builder.Clear();
                    List<string> units = GetUnitsForCurrency(phase, tens);

                    builder.AppendFormat("{0}{1}{2}{3}{4}{5}",
                        SetSpaceBeforeString(Dictionary.Hundreds[hundreds]),
                        SetSpaceBeforeString(Dictionary.Tens[tens]),
                        SetSpaceBeforeString(Dictionary.AboveTen[aboveTens]),
                        SetSpaceBeforeString(units[unity]),
                        SetSpaceBeforeString(Dictionary.Endings[order, GetGrammarForm(unity, sumAboveUnity)]),
                        SetSpaceBeforeString(tempPartialResult));
                }

                order += 1;
                tempNumber /= 1000;
            }

            builder.Append(SetSpaceBeforeString(CurrencyDeflation.GetDeflationPhrase(phase, GetCurrencyGrammarForm(number))));

            return builder.ToString().Trim();
        }

        private List<string> GetUnitsForCurrency(DeflationPhraseType phase, int tens)
        {
            var properUnits = Dictionary.Units;

            if (phase == DeflationPhraseType.AfterComma && CurrencyDeflation is ICurrencyNotMaleDeflectionAfterComma && tens == 0)
                properUnits = (CurrencyDeflation as ICurrencyNotMaleDeflectionAfterComma).GetAfterCommaUnity();

            if (phase == DeflationPhraseType.BeforeComma && CurrencyDeflation is ICurrencyNotMaleDeflectionBeforeComma)
                properUnits = (CurrencyDeflation as ICurrencyNotMaleDeflectionBeforeComma).GetBeforeCommaUnity();

            return properUnits;
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

        private int GetCurrencyGrammarForm(long number)
        {
            long hundreds = (number % 1000) / 100;
            long tens = (number % 100) / 10;
            long unity = number % 10;

            // np. jeden milion
            if( unity == 1 && (hundreds + tens == 0) )
                return 0;

            // np. dwa/trzy/cztery miliony
            if (tempGrammarForm.Contains(unity) && tens != 1)
                return 1;

            // np. dwanaście milionów 
            return 2;
        }

        private int GetGrammarForm(int unity, int sumAboveUnity)
        {
            // np. jeden tysiąc
            if (unity == 1 && sumAboveUnity == 0)
                return  0;

            if (tempGrammarForm.Contains(unity))
                return 1;

            return 2;
        }
    }
}
