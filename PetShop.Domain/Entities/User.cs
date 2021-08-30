using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetShop.Domain.Common;

namespace PetShop.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public int UserType { get; set; } = 1;
        public int Active { get; set; } = 1;

        public List<Pet> Pets { get; set; }
    }
}