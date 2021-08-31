using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.DTO
{
    public interface IRequestId
    {
        public int UserId { get; set; }
        public int PetId { get; set; }
        public int VisitId { get; set; }
    }
}
