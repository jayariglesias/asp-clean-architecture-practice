using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Mappings;
using PetClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Application.Visits.Dtos
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
