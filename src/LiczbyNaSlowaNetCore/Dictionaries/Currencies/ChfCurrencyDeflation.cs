namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public sealed class ChfCurrencyDeflation : BaseCurrencyDeflation
    {
        public override Currency CurrencyCode => Currency.CHF;
        public override string[,] Phases => 
            new[,]
            {
                {"", "", ""},
                {"frank szwajcarski", "franki szwajcarskie", "franków szwajcarskich"},
                {"centym", "centymy", "centymów"}
            };
    }
}