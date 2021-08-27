using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Domain.Common;

namespace PetShop.Application.Common.DTO
{
    public class UserRequest : IdRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; } = 1;
        public int Active { get; set; } = 1;
    }
}
