using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EarthEscape.Utils
{
	public class Constant
	{
        public const string inputCannotBeEmpty = "Input can not be empty.";
		public const string incorrectSymbol = "Incorrect symbol, please check your input and submmit again.";
		public const string isNotRepetable = @"The symbol {0} is not repeatable.";
		public const string symbolRepeatedMoreThanLimit = @"The symbol {0} cannot be repeated consecutively more than {1} times.";
		public const string symbolCannotBeSubtracted = @"The symbol {0} cannot be subtracted.";
		public const string cannotBeSubtractedFrom = @"{0} cannot be subtracted from {1}.";
        public const string noIdeaWhatYouAreTalkingAbout = "I have no idea what you are talking about.";
        public const string successfullySetIntergalacticSymbol = "You've set intergalactic symbol successfully.";
        public const string successfullySetUnit = "You've set unit successfully.";
	}
}