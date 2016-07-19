using EarthEscape.BaseClass;
using EarthEscape.Interfaces;
using EarthEscape.Utils;
using EarthEscape.Utils.Enum;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace EarthEscape.Validators
{
    [Export(typeof(IValidator))]
    [ExportMetadata("Type", ValidationType.SymbolValid)]
    public class SymbolValidValidator : IValidator
    {
        public List<string> Process(string input)
        {
            List<string> validations = new List<string>();
            if(input.Count()==0)
            {
                validations.Add(Constant.inputCannotBeEmpty);
            }
            for (int i = 0; i < input.Count(); i++)
            {
                if (!Context.SymbolList.Contains(input[i]))
                {
                    validations.Add(Constant.incorrectSymbol);
                }
            }
            return validations;
        }
    }
}