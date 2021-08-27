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

namespace PetShop.Application.Users.Queries
{

    public class DeleteUserCommand: IRequest<Response<object>>
    {
        public DeleteUserCommand(UserRequest e)
        {
            UserId = e.UserId;
        }

        public int UserId { get; set; }

    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<object>>
    {
        private readonly IDataContext _context;

        public DeleteUserCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var data = _context.Users.FirstOrDefault(x => x.UserId == request.UserId);
            if (data != null)
            {
                _context.Users.Remove(data);
                _context.SaveChanges();
                return await Task.FromResult(new Response<object>(Message.Success(),true));
            }

            return await Task.FromResult(new Response<object>(Message.NotFound("User")));
        }

    }
}
