using EarthEscape.BaseClass;
using EarthEscape.Utils.Enum;
using System.Collections.Generic;

namespace EarthEscape.Utils
{
    public static class Utility
    {
        public static Relation RelationToNextSymbol(char pSymbol, char nSymbol, Dictionary<char, Symbol> symbolMap)
        {
            Relation returnValue = Relation.None;
            if (symbolMap[pSymbol].Value > symbolMap[nSymbol].Value)
                returnValue = Relation.GreaterThan;
            else if (symbolMap[pSymbol].Value == symbolMap[nSymbol].Value)
                returnValue = Relation.Equal;
            else if (symbolMap[pSymbol].Value < symbolMap[nSymbol].Value)
                returnValue = Relation.LessThan;
            return returnValue;
        }
    }
}