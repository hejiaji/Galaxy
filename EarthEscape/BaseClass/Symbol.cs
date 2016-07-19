using EarthEscape.Utils.Enum;
using System.Collections.Generic;

namespace EarthEscape.BaseClass
{
	public class Symbol
	{
        public Symbol()
        { 
        }
        public Symbol(SymbolType type, int value, List<SymbolType> deductibleList, int maxRepeatTime)
		{
            this.Type = type;
            this.Value = value;
            this.DeductibleList = deductibleList;
            this.MaxRepeatTime = maxRepeatTime;
		}

        public SymbolType Type { get; set; }
        public int Value { get; set; }
        public List<SymbolType> DeductibleList { get; set; }
        public bool IsRepeatable { get { return MaxRepeatTime > 2; } }
        public int MaxRepeatTime { get; set; }

        public override string ToString()
        {
            return Type.ToString();
        }
	}
}