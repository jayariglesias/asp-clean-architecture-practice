using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.DTO
{
    public class PetRequest : IdRequest
    {
        public int PetType { get; set; }
        public string PetName { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
