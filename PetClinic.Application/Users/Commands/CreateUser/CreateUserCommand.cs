using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Response<object>>
    {
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
            var data = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };

            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync(cancellationToken);

            if (data.UserId == 0 || data == null)
            {
                throw new ApiException(Message.Custom("Data was not saved!"));
            }
            else
            {
                return await Task.FromResult(new Response<object>(data, Message.Success()));
            }
        }
    }

}
