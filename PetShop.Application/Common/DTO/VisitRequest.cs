using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.DTO
{
    public class VisitRequest : PetRequest
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime VisitFrom { get; set; }
        public DateTime VisitTo { get; set; }
        public string Notes { get; set; }
    }
}
