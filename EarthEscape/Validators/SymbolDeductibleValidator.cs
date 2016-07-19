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
    [ExportMetadata("Type",ValidationType.SymbolDeductible)]
    public class SymbolDeductibleValidator : IValidator
    {
        public List<string> Process(string input)
        {
            List<string> validations = new List<string>();
            var symbolMap = Context.SymbolMap;
            for (int i = 0; i < input.Count() - 1; i++)
            {
                Relation relation = Utility.RelationToNextSymbol(input[i], input[i + 1], symbolMap);
                if (relation == Relation.LessThan)
                {
                    var deductibleList = symbolMap[input[i]].DeductibleList;
                    if (deductibleList == null || deductibleList.Count == 0)
                    {
                        validations.Add(string.Format(Constant.symbolCannotBeSubtracted, input[i]));
                        break;
                    }
                    else if (!deductibleList.Contains(symbolMap[input[i + 1]].Type))
                    {
                        validations.Add(string.Format(Constant.cannotBeSubtractedFrom, input[i], input[i + 1]));
                        break;
                    }
                }
            }
            return validations;
        }
    }
}