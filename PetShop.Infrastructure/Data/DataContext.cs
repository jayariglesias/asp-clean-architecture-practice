using Microsoft.EntityFrameworkCore;
using PetShop.Application.Common.Interfaces;
using PetShop.Domain.Entities;
using PetShop.Domain.Common;
using System.Threading.Tasks;
using System.Threading;

namespace PetShop.Infrastructure.Data
{
    public class DataContext : DbContext, IDataContext
    {
        // private readonly IDatetime _dateTime;

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Visit> Visits { get; set; }

    }
}
