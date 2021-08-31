using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Wrappers
{
    public class Message
    {
        public static string Welcome()
        {
            return "Welcome to PetShop";
        }

        public static string Custom(string x)
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
            return "Failed! Please fill all the fields.";
        }

        public static string FailedTaken(string x = "Data")
        {
            return $"Failed! { x } already taken.";
        }

        public static string FailedDate()
        {
            return "Failed! Invalid date format.";
        }

        public static string NotFound(string x)
        {
            return $"Failed! { x } not found!";
        }

        public static string Success(string x = null)
        {
            return x ?? "Success!";
        }
    }
}