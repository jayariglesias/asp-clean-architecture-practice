
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Mappings;
using PetClinic.Domain.Entities;
using System.Collections.Generic;

namespace PetClinic.Application.Users.Dtos
{
    public class UserDto : IMapFrom<User>, IUser
    {
        public UserDto()
        {
            Pets = new List<PetDto>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public bool Active { get; set; }
        public IList<PetDto> Pets { get; set; }
    }
}  