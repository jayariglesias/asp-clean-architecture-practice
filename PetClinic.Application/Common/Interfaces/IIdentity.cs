using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Application.Common.Interfaces
{
    public interface IIdentity
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
