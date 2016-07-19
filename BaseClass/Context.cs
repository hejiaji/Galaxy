using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EarthEscape.BaseClass
{
    public static class Context
    {
        public static Dictionary<string, Symbol> IntergalacticMap{ get; set; }
        public static Dictionary<string, double> UnitsMap { get; set; }
        public static string Currency { get; set; }
        public static Dictionary<char, Symbol> SymbolMap { get; set; }
        public static List<char> SymbolList { get; set; }

        static Context()
        {
            IntergalacticMap = new Dictionary<string, Symbol>();
            UnitsMap = new Dictionary<string, double>();
            SymbolMap = new Dictionary<char, Symbol>();
            SymbolList = new List<char>();
            Currency = "";
        }

        public static string translateToRoman(IEnumerable<string> IntergalacticSymbols)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var symbol in IntergalacticSymbols)
            {
                sb.Append(IntergalacticMap[symbol].ToString());
            }
            return sb.ToString();
        }
    }
}