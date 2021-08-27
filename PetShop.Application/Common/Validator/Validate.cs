using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PetShop.Application.Common.Validator
{
    public class Validate
    {
        public static bool String(string x)
        {
            if(string.IsNullOrWhiteSpace(x))
            {
                return false;
            }

            return true;
        }

        public static bool Int(int x)
        {
            if (double.IsNaN(x))
            {
                return false;
            }

            return true;
        }

        public static bool IsDateTime(string x)
        {
            DateTime tempDate;
            return DateTime.TryParse(x, out tempDate);
        }

        public static bool String(List<string> x)
        {

            foreach (string v in x)
            {
                if(string.IsNullOrWhiteSpace(v))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
