using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Interfaces
{
    public interface IVisit
    {
        public int VisitId { get; set; }
        public int PetId { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
    }
}
