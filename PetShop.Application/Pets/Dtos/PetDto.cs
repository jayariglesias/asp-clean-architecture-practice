using AutoMapper;
using Newtonsoft.Json;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Mappings;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Pets.Dtos
{
    public class PetDto : IMapFrom<Pet>, IPet
    {
        public PetDto()
        {
            Visits = new List<VisitDto>();
        } 

        public int PetId { get; set; }
        public int UserId { get; set; }
        public string PetName { get; set; }
        public DateTime Birthdate { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public IList<VisitDto> Visits { get; set; }

        [JsonProperty(PropertyName = "Owner")]
        public UserDto User { get; set; }
    }
}