using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Mappings;
using PetClinic.Application.Pets.Dtos;
using PetClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Application.Visits.Dtos
{
    public class VisitDto : IMapFrom<Visit>, IVisit
    {
        public int VisitId { get; set; }
        public int PetId { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
        public PetDto Pet { get; set; }
    }
}
