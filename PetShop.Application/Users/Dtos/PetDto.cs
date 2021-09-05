using PetShop.Application.Common.Mappings;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Users.Dtos
{
    public class PetDto : IMapFrom<Pet>
    {
        public string PetName { get; set; }
        public int PetId { get; set; }
        public DateTime Birthdate { get; set; }
    }
}