using EarthEscape.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace EarthEscape.Managers
{
    [Export(typeof(IParserManager))]
    public class ParserManager : IParserManager
    {
        [ImportMany]
        IEnumerable<IParser> Parsers;
        public ParserManager()
        { 
        }

        public string Process(string input)
        {
            string message = string.Empty;
            foreach (var parser in Parsers)
            {
                message = parser.Parse(input);
                if (!string.IsNullOrEmpty(message))
                    break;
            }
            return message;
        }
    }
}