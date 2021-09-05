using Microsoft.Extensions.Configuration;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Common.Interfaces
{
    public interface IToken
    {
       Task<string> Create(User user, int minutes);
    }
}
