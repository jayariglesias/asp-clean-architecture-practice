using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.DTO;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Validator;
using PetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Application.Users.Command
{
    public class CreateUserCommand : IRequest<Response<object>>
    {
        public CreateUserCommand(UserRequest e)
        {
            FirstName = e.FirstName;
            LastName = e.LastName;
            MiddleName = e.MiddleName;
            Email = e.Email;
            Username = e.Username;
            Password = e.Password;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<object>>
    {
        private readonly IDataContext _context;
        public CreateUserCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            if(!Validate.String(request.FirstName)) return await Task.FromResult(new Response<object>(Message.FailedString("First name")));
            if(!Validate.String(request.LastName)) return await Task.FromResult(new Response<object>(Message.FailedString("Last name")));
            if(!Validate.String(request.Email)) return await Task.FromResult(new Response<object>(Message.FailedString("Email")));
            if(!Validate.String(request.Username)) return await Task.FromResult(new Response<object>(Message.FailedString("Username")));
            if(!Validate.String(request.Password)) return await Task.FromResult(new Response<object>(Message.FailedString("Password")));

            var checkUser = _context.Users.FirstOrDefault(u => 
                u.Username.ToLower() == request.Username.ToLower() ||
                u.Email.ToLower() == request.Email.ToLower()
            );

            if(checkUser != null)
            {
                if (checkUser.Username.ToLower() == request.Username.ToLower()) return await Task.FromResult(new Response<object>(Message.FailedTaken("Username")));
                if (checkUser.Email.ToLower() == request.Email.ToLower()) return await Task.FromResult(new Response<object>(Message.FailedTaken("Email")));
            }

            var data = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };

            _context.Users.Add(data);
            _context.SaveChanges();

            if (data.UserId == 0 || data == null)
                return await Task.FromResult(new Response<object>(Message.Custom("Failed to save data!")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
