using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Interfaces
{
    public interface IVisitRange
    {
        public DateTime VisitFrom { get; set; }
        public DateTime VisitTo { get; set; }
    }
}
