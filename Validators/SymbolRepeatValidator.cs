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
    [ExportMetadata("Type", ValidationType.SymbolRepeat)]
    public class SymbolRepeatValidator : IValidator
    {
        public List<string> Process(string input)
        {
            List<string> validations = new List<string>();
            var symbolMap = Context.SymbolMap;
            int repeatCount = 1;
            char repeatSymbol = '\0';
            for (int i = 0; i < input.Count() - 1; i++)
            {
                Relation relation = Utility.RelationToNextSymbol(input[i], input[i + 1], symbolMap);
                if (relation == Relation.Equal)
                {
                    if (!symbolMap[input[i]].IsRepeatable)
                    {
                        validations.Add(string.Format(Constant.isNotRepetable, input[i]));
                        break;
                    }
                    else
                    {
                        // check if the repeat time exceed the limit
                        if (repeatSymbol == input[i])
                        {
                            if (repeatCount + 1 > symbolMap[input[i]].MaxRepeatTime)
                            {
                                validations.Add(string.Format(Constant.symbolRepeatedMoreThanLimit, input[i], symbolMap[input[i]].MaxRepeatTime));
                                break;
                            }
                            else
                                repeatCount++;
                        }
                        else
                        {
                            repeatSymbol = input[i];
                            repeatCount = 2;
                        }
                    }
                }
                // Reset repeat Symbol and count
                else
                {
                    repeatCount = 1;
                    repeatSymbol = '\0';
                }
            }
            return validations;
        }
    }
}