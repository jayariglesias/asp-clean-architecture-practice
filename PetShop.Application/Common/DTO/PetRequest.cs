﻿using PetShop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.DTO
{
    public class PetRequest : IUser,IRequestId, IPet
    {
        public int UserId { get; set; }
        public int PetId { get; set; }
        public int VisitId { get; set; }
        public int PetType { get; set; }
        public string PetName { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Active { get; set; }
    }
}
