using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.DTO
{
    public class IdRequest
    {
        public int UserId { get; set; }
        public int PetId { get; set; }
        public int VisitId { get; set; }
    }
}
