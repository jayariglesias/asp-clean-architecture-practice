using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Interfaces
{
    public interface IIdentity
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
