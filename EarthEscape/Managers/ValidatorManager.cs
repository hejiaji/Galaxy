using EarthEscape.BaseClass;
using EarthEscape.Interfaces;
using EarthEscape.Utils.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace EarthEscape.Managers
{
    [Export(typeof(IValidatorManager))]
    public class ValidatorManager:IValidatorManager
    {
        [ImportMany]
        IEnumerable<Lazy<IValidator,IValidatorMetaData>> Validators;

        public List<string> Validate(string input)
        {
            List<string> validations = new List<string>();
            for (int i = 1; i <= Validators.Count(); i++)
            {
                if (validations.Count > 0)
                    break;
                IValidator validator = Validators.Where(v => v.Metadata.Type == (ValidationType)i).First().Value;
                validations.AddRange(validator.Process(input));
            }
            return validations;
        }
    }
}