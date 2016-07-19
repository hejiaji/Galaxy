using EarthEscape.Utils;
using EarthEscape.Utils.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EarthEscape.BaseClass
{
    public static class DataInitialization
    {
        private static Dictionary<char, Symbol> symbolMap;
        private static List<char> symbolList;

        static DataInitialization()
        {
            symbolMap = new Dictionary<char, Symbol>();
            symbolList = new List<char>();
            initializeSymbolMap();
            initializeSymbolList();
        }

        public static void Initialize()
        {
            Context.SymbolMap = symbolMap;
            Context.SymbolList = symbolList;
        }

        private static void initializeSymbolMap()
        {
            symbolMap.Add(convertToChar(SymbolType.I), new Symbol(SymbolType.I, 1, new List<SymbolType>() { SymbolType.V, SymbolType.X }, 3));
            symbolMap.Add(convertToChar(SymbolType.V), new Symbol(SymbolType.V, 5, new List<SymbolType>(), 1));
            symbolMap.Add(convertToChar(SymbolType.X), new Symbol(SymbolType.X, 10, new List<SymbolType>() { SymbolType.L, SymbolType.C }, 3));
            symbolMap.Add(convertToChar(SymbolType.L), new Symbol(SymbolType.L, 50, new List<SymbolType>(), 1));
            symbolMap.Add(convertToChar(SymbolType.C), new Symbol(SymbolType.C, 100, new List<SymbolType>() { SymbolType.D, SymbolType.M }, 3));
            symbolMap.Add(convertToChar(SymbolType.D), new Symbol(SymbolType.D, 500, new List<SymbolType>(), 1));
            symbolMap.Add(convertToChar(SymbolType.M), new Symbol(SymbolType.M, 1000, new List<SymbolType>(), 3));
        }

        private static void initializeSymbolList()
        {
            var _list = symbolMap.Keys.Select(x => x.ToString()).ToList();
            foreach (var s in _list)
            {
                symbolList.AddRange(s.ToCharArray());
            }
        }

        private static char convertToChar(SymbolType type)
        {
            return type.ToString()[0];
        }
    }
}