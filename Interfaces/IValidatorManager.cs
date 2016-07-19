using EarthEscape.BaseClass;
using System.Collections.Generic;

namespace EarthEscape.Interfaces
{
    interface IValidatorManager
    {
        List<string> Validate(string input);
    }
}
