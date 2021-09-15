using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Application.Common.Wrappers
{
    public class Message
    {
        public static string Welcome()
        {
            return "Welcome to PetClinic";
        }

        public static string Custom(string x)
        {
            return x;
        }

        public static string FailedString(string x)
        {
            return $"{ x } must not be null or contain white spaces.";
        }

        public static string FailedInt(string x)
        {
            return $"{ x } must a integer number.";
        }

        public static string FailedFields()
        {
            return "Please fill all the fields.";
        }

        public static string FailedTaken(string x = "Data")
        {
            return $"{ x } already taken.";
        }

        public static string FailedDate()
        {
            return "Invalid date format.";
        }

        public static string NotFound(string x)
        {
            return $"{ x } not found!";
        }

        public static string Success(string x = null)
        {
            return x ?? "Success!";
        }
    }
}