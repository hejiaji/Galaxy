using EarthEscape.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace EarthEscape.Parsers
{
    [Export(typeof(IParser))]
    public class QuestionParser : IParser
    {
        [Import]
        private ISolverManager solverManager { get; set; }
        public string Parse(string input)
        {
            if (!input.EndsWith("?"))
                return string.Empty;
            return solverManager.Process(input);
        }
    }
}