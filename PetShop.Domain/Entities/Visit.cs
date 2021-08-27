using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PetShop.Domain.Common;

namespace PetShop.Domain.Entities
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }

        [Required]
        public int PetId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int VisitType { get; set; }

        [Required]
        public DateTime VisitDate { get; set; } = DateTime.Now;

        [Required]
        public string Notes { get; set; }
    }
}
