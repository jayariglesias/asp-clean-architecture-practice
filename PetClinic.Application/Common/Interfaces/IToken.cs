using Microsoft.Extensions.Configuration;
using PetClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Application.Common.Interfaces
{
    public interface IToken
    {
       Task<string> Create(User user, int minutes);
    }
}
