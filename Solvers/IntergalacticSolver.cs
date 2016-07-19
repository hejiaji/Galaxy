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
    public class IntergalacticSolver : ISolver
    {
        [Import]
        private ITranslatorManager translatorManager { get; set; }
        [Import]
        private IValidatorManager validatorManager { get; set; }
        public string solve(string question)
        {
            string qulifier = "how much is";
            if (!question.StartsWith(qulifier))
            {
                return string.Empty;
            }
            string body = question.Substring(qulifier.Length + 1, question.Length - qulifier.Length - 2);
            var lexers = body.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string roman = Context.translateToRoman(lexers.Take(lexers.Length));
            List<string> validations = validatorManager.Validate(roman);
            if (validations.Count > 0)
            {
                return validations.First();
            }

            string answer = translatorManager.Process(roman);
            return string.Format("{0} is {1}", body, answer);
        }
    }
}