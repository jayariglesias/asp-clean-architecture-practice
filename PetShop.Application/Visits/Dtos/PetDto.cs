using Newtonsoft.Json;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Mappings;
using PetShop.Domain.Entities;
using System;

namespace PetShop.Application.Visits.Dtos
{
    public class PetDto : IMapFrom<Pet>, IPet
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public UserDto User { get; set; }
    }
}
