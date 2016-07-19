using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EarthEscape.BaseClass;
using EarthEscape.Interface;
using EarthEscape.Utils;
using System.ComponentModel.Composition;
using EarthEscape.Utils.Enum;

namespace EarthEscape.Manager
{
    [Export(typeof(ITranslatorManager))]
	public class TranslatorManager : ITranslatorManager
	{
		public TranslatorManager()
		{
		}

		public string Process(string input)
		{
            var symbolMap = Context.SymbolMap;
			int totalValue = 0;
			for (int i = 0; i < input.Count(); i++)
			{
				if (i == input.Count() - 1)
				{
					totalValue += symbolMap[input[i]].Value;
					break;
				}
				Relation relation = Utility.RelationToNextSymbol(input[i], input[i + 1], symbolMap);
				if (relation == Relation.GreaterThan)
				{
					totalValue += symbolMap[input[i]].Value;
				}
				else if (relation == Relation.Equal)
				{
					totalValue += symbolMap[input[i]].Value;
				}
				else if (relation == Relation.LessThan)
				{
					totalValue = totalValue + symbolMap[input[i + 1]].Value - symbolMap[input[i]].Value;
					i++;
				}
			}
			return totalValue.ToString();
		}
	}
}