using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace InstutiteOfFineArt.Codes
{
    public class ValidateClass
    {
        public static bool Validate_Require(string valid)
        {
            if (valid == null || valid == "")
                return false;
            else
                return true;
        }

        public static bool Validate_Number(string valid)
        {
            int outValid;
            if (int.TryParse(valid, out outValid))
                return true;
            else
                return false;
        }

        public static bool Validate_Datetime(string valid)
        {
            DateTime outDate;
            if (DateTime.TryParse(valid, out outDate))
                return true;
            else
                return false;
        }

        public static bool Validate_Length(string valid, int min, int max)
        {
            if (valid.Length <= max && valid.Length >= min)
                return true;
            else
                return false;
        }

        public static bool Validate_Email(string valid)
        {
            Regex re = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
            if (re.IsMatch(valid))
                return true;
            else
                return false;
        }
    }
}