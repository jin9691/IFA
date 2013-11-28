using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace InstutiteOfFineArt.Codes
{
    public class ValidateClass
    {
        private static List<string> FILE_TYPE  = new List<string>{ ".PNG",".JPG",".JPEG",".GIF",".png",".jpeg",".jpg",".gif"};
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

        public static bool Validate_FileType(FileUpload flImage)
        {
            if (flImage == null)
                return false;
            String extention = Path.GetExtension(flImage.FileName);
            if (string.IsNullOrWhiteSpace(extention) || !FILE_TYPE.Contains(extention))
            {
                return false;
            }
            return true;
            
        }

        public static bool Validate_Image_Require(FileUpload flImage) {
            if (flImage == null || !flImage.HasFile)
                return false;
            return true;
        }
    }
}