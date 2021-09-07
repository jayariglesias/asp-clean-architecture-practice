﻿
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Mappings;
using PetShop.Domain.Entities;
using System.Collections.Generic;

namespace PetShop.Application.Users.Dtos
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
        public int UserType { get; set; }
        public int Active { get; set; }
        public IList<PetDto> Pets { get; set; }
    }
}  