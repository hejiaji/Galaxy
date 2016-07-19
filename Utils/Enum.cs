using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EarthEscape.Utils.Enum
{
	public enum SymbolType
	{
		I,
		V,
		X,
		L,
		C,
		D,
		M
	}

	public enum Relation
	{
 		GreaterThan,
		LessThan,
		Equal,
		None
	}

    public enum ValidationType
    {
        SymbolValid = 1,
        SymbolRepeat=2,
        SymbolDeductible=3
    }
}
