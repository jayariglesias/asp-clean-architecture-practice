using PetClinic.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinic.Infrastructure.Persistence.Context
{
    public static class DataSeeder
    {
        public static async Task UserAdminSeed(DataContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    FirstName = "Luffy",
                    LastName = "Monkey",
                    MiddleName = "D",
                    Email = "admin@admin.com",
                    Username = "admin",
                    Password = "1234",
                    UserType = 1,
                    Active = 1,
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
