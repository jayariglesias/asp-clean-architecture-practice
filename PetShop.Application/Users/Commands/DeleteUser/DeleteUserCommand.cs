using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Users.Commands.DeleteUser
{

    public class DeleteUserCommand: IRequest<Response<int>>
    {
        public int UserId { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<int>>
    {
        private readonly IDataContext _context;

        public DeleteUserCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            if (data == null)
            {
                throw new ApiException("User not existed in the database.");
            }

            _context.Users.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(new Response<int>(Message.Success(),true));
        }

    }
}
