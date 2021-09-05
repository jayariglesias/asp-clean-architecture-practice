using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Interfaces
{
    public interface IPet
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
