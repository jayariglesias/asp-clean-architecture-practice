using AutoMapper;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Mappings;
using PetClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PetClinic.Application.Users.Dtos
{
    public class PetDto : IMapFrom<Pet>, IPet
    {
        public PetDto()
        {
            Visits = new List<VisitDto>();
        }

        public int UserId { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public DateTime Birthdate { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public IList<VisitDto> Visits { get; set; }
    }
}