using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Mappings;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Users.Dtos
{
    public class VisitDto : IMapFrom<Visit>, IVisit
    {
        public int VisitId { get; set; }
        public int PetId { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
    }
}
