
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Mappings;
using PetClinic.Domain.Entities;
using System.Collections.Generic;

namespace PetClinic.Application.Pets.Dtos
{
    public class UserDto : IMapFrom<User>, IUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public int Active { get; set; }

    }
}  