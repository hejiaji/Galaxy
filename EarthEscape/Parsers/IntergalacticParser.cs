using EarthEscape.BaseClass;
using EarthEscape.Interfaces;
using EarthEscape.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace EarthEscape.Parsers
{
    [Export(typeof(IParser))]
    public class IntergalacticParser : IParser
    {
        public string Parse(string input)
        {
            if (input.EndsWith("?"))
                return string.Empty;
            var lexers = input.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (lexers.Count() != 2)
                return string.Empty;
            if (lexers[1].Length > 1)
                return string.Empty;
            Symbol roman = null;
            if (!Context.SymbolMap.ContainsKey(lexers[1][0]))
                return string.Empty;
            roman = Context.SymbolMap[lexers[1][0]];
            var name = lexers[0].Trim();
            Context.IntergalacticMap[name] = roman;
            return Constant.successfullySetIntergalacticSymbol;
        }
    }
}