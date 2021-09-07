using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Mappings;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Visits.Dtos
{
    public class UserDto : IMapFrom<User>, IUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int UserType { get; set; }
        public int Active { get; set; }
    }
}
