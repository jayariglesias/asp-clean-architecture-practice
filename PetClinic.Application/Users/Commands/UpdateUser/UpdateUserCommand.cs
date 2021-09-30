using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace PetClinic.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Response<object>>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
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
            var usernameExist = await _context.Users.Where(x => x.Username == request.Username && x.UserId != request.UserId).FirstOrDefaultAsync();
            var emailExist = await _context.Users.Where(x => x.Email == request.Email && x.UserId != request.UserId).FirstOrDefaultAsync();

            if (data == null)
            {
                throw new ApiException(Message.NotFound("User"));
            }
            else if (usernameExist != null)
            {
                throw new ApiException(Message.Custom("Username is existed in the database."));
            }
            else if (emailExist != null)
            {
                throw new ApiException(Message.Custom("Email is existed in the database."));
            }
            else
            {
                data.LastName = request.LastName ?? data.LastName;
                data.MiddleName = request.MiddleName ?? data.MiddleName;
                data.Email = request.Email ?? data.Email;
                data.Username = request.Username ?? data.Username;
                data.Password = request.Password ?? data.Password;
                data.Active = request.Active;
                await _context.SaveChangesAsync(cancellationToken);

                if (data.UserId == 0)
                {
                    throw new ApiException(Message.Custom("Data did not update in the database!"));
                }
                else
                {
                    return await Task.FromResult(new Response<object>(data, Message.Success()));
                }
            }
        }
    }
}
