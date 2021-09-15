using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Domain.Entities;

namespace PetClinic.Infrastructure.Persistence.Context
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PetClinic");

            modelBuilder.Entity<Pet>()
                .HasOne(pet => pet.User)
                .WithMany(user => user.Pets)
                .HasForeignKey(pet => pet.UserId)
                .HasPrincipalKey(user => user.UserId);

            modelBuilder.Entity<Visit>()
                .HasOne(visit => visit.Pet)
                .WithMany(pet => pet.Visits)
                .HasForeignKey(visit => visit.PetId)
                .HasPrincipalKey(pet => pet.PetId);
        }
    }
}
