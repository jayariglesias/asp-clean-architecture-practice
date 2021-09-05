using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PetShop.Domain.Entities;

namespace PetShop.Application.Common.Interfaces
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pet> Pets { get; set; }
        DbSet<Visit> Visits { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
