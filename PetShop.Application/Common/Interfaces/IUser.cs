using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Interfaces
{
    public interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Active { get; set; }
    }
}
