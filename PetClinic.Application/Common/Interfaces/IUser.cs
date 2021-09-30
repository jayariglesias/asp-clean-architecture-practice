using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Application.Common.Interfaces
{
    public interface IUser
    {
        public int UserId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int UserType { get; set; }
        public bool Active { get; set; }
    }
}
