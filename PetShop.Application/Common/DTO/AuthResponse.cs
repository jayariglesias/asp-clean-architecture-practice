using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Domain.Entities;

public class AuthResponse
{

    public AuthResponse(User user, string token)
    {
        UserId = user.UserId;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Token = token;
    }

    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }

}
