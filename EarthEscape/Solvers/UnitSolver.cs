using EarthEscape.BaseClass;
using EarthEscape.Interface;
using EarthEscape.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace EarthEscape.Solvers
{
    [Export(typeof(ISolver))]
    public class UnitSolver: ISolver
    {
        [Import]
        private ITranslatorManager translatorManager { get; set; }
        [Import]
        private IValidatorManager validatorManager { get; set; }
        public string solve(string question)
        {
            var currency = Context.Currency;
            var qulifier = String.Format("how many {0} is", currency);
            if (!question.StartsWith(qulifier))
            {
                return "";
            }
            string body = question.Substring(qulifier.Length + 1, question.Length - qulifier.Length - 2);
            var lexers = body.Split( new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string unit = lexers.Last().Trim();
            double unitValue = Context.UnitsMap[unit];
            string roman = Context.translateToRoman(lexers.Take(lexers.Length - 1));

            List<string> validations = validatorManager.Validate(roman);
            if (validations.Count > 0)
            {
                return validations.First();
            }
            int calculatedValue = int.Parse(translatorManager.Process(roman));
            string answer = calculatedValue * unitValue + " " + currency;
            return string.Format("{0} is {1}", body, answer);
        }
    }
}