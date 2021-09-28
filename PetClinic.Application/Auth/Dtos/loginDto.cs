using PetClinic.Domain.Entities;

namespace PetClinic.Application.Auth.Dtos
{
    public class loginDto
    {
        public loginDto(User user, string token)
        {
            Token = token;
            CurrentUser = new currentUser(user);
        }

        public currentUser CurrentUser { get; set; }
        public string Token { get; set; }
    }

    public class currentUser
    {
        public currentUser(User user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            UserType = user.UserType;
        }

        public int UserId { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
