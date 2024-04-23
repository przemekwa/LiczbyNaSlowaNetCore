
// Copyright (c) 2014 Przemek Walkowski

namespace LiczbyNaSlowaNETCore.Dictionaries
{
    using System.Collections.Generic;
    using LiczbyNaSlowaNetCore.Interfaces;

    public class PolishDictionary : IDeclensionDictionary
    {
        public List<string> Units 
            => new List<string> { string.Empty, "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "zero" };
        public List<string> AboveTen 
            => new List<string> { string.Empty, "jedenaście", "dwanaście", "trzynaście", "czternaście", "piętnaście", "szesnaście", "siedemnaście", "osiemnaście", "dziewiętnaście" };
        public List<string> Tens 
            => new List<string> { string.Empty, "dziesięć", "dwadzieścia", "trzydzieści", "czterdzieści", "pięćdziesiąt", "sześćdziesiąt", "siedemdziesiąt", "osiemdziesiąt", "dziewięćdziesiąt" };
        public List<string> Hundreds
            => new List<string> { string.Empty, "sto", "dwieście", "trzysta", "czterysta", "pięćset", "sześćset", "siedemset", "osiemset", "dziewięćset" };
        public string[,] Endings => new string[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "tysiąc", "tysiące", "tysięcy" },
            { "milion", "miliony", "milionów" },
            { "miliard", "miliardy", "miliardów" },
            { "bilion", "biliony", "bilionów" },
            { "biliard", "biliardy", "biliardów" },
            { "trylion", "tryliony", "trylionów" },
        };
        public List<string> Sign => new List<string> { "plus", "minus" };
        public string[,] Current => new string[,]
        {
            { string.Empty, string.Empty, string.Empty },
            { "złoty", "złote", "złotych" },
            { "grosz", "grosze", "groszy" }
        };
        public bool HasStems { get; } = true;
    }
}