using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Validator
{
    public class Message
    {
        public static string Welcome()
        {
            return "Welcome to PetShop";
        }
        public static string Value(string x)
        {
            return x;
        }

        public static string FailedString(string x)
        {
            return $"Failed! { x } must not be null or contain white spaces.";
        }

        public static string FailedInt(string x)
        {
            return $"Failed! { x } must a integer number.";
        }

        public static string FailedFields()
        {
            return "Failed! Please fill all the fields!";
        }

        public static string NotFound(string x)
        {
            return $"{ x } Not Found!";
        }

        public static string Success(string x = null)
        {
            return x ?? "Success!";
        }
    }
}