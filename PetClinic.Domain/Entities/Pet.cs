using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PetClinic.Domain.Common;

namespace PetClinic.Domain.Entities
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

        public User User { get; set; }
        public List<Visit> Visits { get; set; }
    }
}