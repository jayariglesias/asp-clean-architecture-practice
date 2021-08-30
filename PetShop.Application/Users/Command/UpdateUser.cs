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
    public class UpdateUserCommand : IRequest<Response<object>>
    {
        public UpdateUserCommand(UserRequest e)
        {
            UserId = e.UserId;
            FirstName = e.FirstName;
            LastName = e.LastName;
            MiddleName = e.MiddleName;
            Email = e.Email;
            Username = e.Username;
            Password = e.Password;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<object>>
    {
        private readonly IDataContext _context;
        public UpdateUserCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var data = _context.Users.FirstOrDefault(x => x.UserId == request.UserId);
            if (data == null)
                return await Task.FromResult(new Response<object>(Message.NotFound("User")));
            else
                data.FirstName = request.FirstName ?? data.FirstName;
                data.LastName = request.LastName ?? data.LastName;
                data.MiddleName = request.MiddleName ?? data.MiddleName;
                data.Email = request.Email ?? data.Email;
                data.Username = request.Username ?? data.Username;
                data.Password = request.Password ?? data.Password;

                _context.Users.Update(data);
                _context.SaveChanges();

                if (data.UserId != 0)
                    return await Task.FromResult(new Response<object>(data, Message.Success()));
                else
                    return await Task.FromResult(new Response<object>(Message.Value("Failed to save data!")));
        }

       
    }
}
