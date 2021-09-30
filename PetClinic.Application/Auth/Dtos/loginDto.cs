using PetClinic.Domain.Entities;

namespace PetClinic.Application.Auth.Dtos
{
    public class LoginDto
    {
        public LoginDto(User user, string token)
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
            Password = user.Password;
            UserType = user.UserType;
            Email = user.Email;
            Active = user.Active;
        }

        public int UserId { get; set; }
        public int UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}
