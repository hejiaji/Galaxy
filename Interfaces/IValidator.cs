using EarthEscape.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthEscape.Interfaces
{
    interface IValidator
    {
        List<string> Process(string input);
    }
}
