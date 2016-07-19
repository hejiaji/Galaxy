using EarthEscape.BaseClass;
using EarthEscape.Interface;
using EarthEscape.Interfaces;
using EarthEscape.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;

namespace EarthEscape.Parsers
{
    [Export(typeof(IParser))]
    public class UnitParser :  IParser
    {
        [Import]
        private ITranslatorManager translatorManager { get; set; }

        public UnitParser()
        {
        }
        public string Parse(string input)
        {
            if (input.EndsWith("?"))
                return string.Empty;
            var lexers = input.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (lexers.Count() != 2)
                return string.Empty;
            var left = lexers[0].Split(' ');
            if (left.Length < 2)
                return string.Empty;
            var rValue = int.Parse(lexers[1].Split(' ')[0]);
            if (string.IsNullOrEmpty(Context.Currency))
            {
                Context.Currency = lexers[1].Split(' ')[1];
            }
            string roman = Context.translateToRoman(left.Take(left.Length - 1));
            int calculatedValue = int.Parse(translatorManager.Process(roman));

            var unit = left.Last();
            var unitValue = (double)rValue / (double)calculatedValue;
            Context.UnitsMap[unit] = unitValue;
            return Constant.successfullySetUnit;
        }
    }
}