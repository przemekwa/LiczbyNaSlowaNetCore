using System;
using System.Collections.Generic;

namespace LiczbyNaSlowaNETCore.Dictionaries.Currencies
{
    public interface ICurrencyNotMaleDeflectionBeforeComma
    {
        List<String> GetBeforeCommaUnity( bool withStems );
    }
}
