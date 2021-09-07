using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Users.Commands.UpdateUser
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
            {
                throw new ApiException(Message.NotFound("User"));
            }
            else
            {
                data.FirstName = request.FirstName ?? data.FirstName;
                data.LastName = request.LastName ?? data.LastName;
                data.MiddleName = request.MiddleName ?? data.MiddleName;
                data.Email = request.Email ?? data.Email;
                data.Username = request.Username ?? data.Username;
                data.Password = request.Password ?? data.Password;

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
