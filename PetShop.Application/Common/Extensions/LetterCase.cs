using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Extensions
{
    public static class LetterCase
    {
        public static string ToLower(string x)
        {
            if (string.IsNullOrWhiteSpace(x))
            {
                return "";
            }
            return x.ToLower();
        }
    }
}
