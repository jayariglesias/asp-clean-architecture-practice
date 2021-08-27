using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PetShop.Domain.Common;

namespace PetShop.Domain.Entities
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PetType { get; set; }

        [Required]
        public string PetName { get; set; }
        
        [Required]
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
    }
}