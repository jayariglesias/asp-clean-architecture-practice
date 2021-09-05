using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Dtos;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Validator;
using PetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Application.Users.Queries
{

    public class GetUserByIdQuery : IRequest<Response<User>>
    {
        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }

        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<User>>
    {
        private readonly IDataContext _context;

        public GetUserByIdQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (!Validate.Int(request.UserId)) return await Task.FromResult(new Response<User>(Message.FailedInt("User id")));
            
            var data = _context.Users
                .Include(u => u.Pets)
                .ThenInclude(p => p.User)
                .Include(u => u.Pets)
                .ThenInclude(v => v.Visits)
                .Where(u => u.UserId == request.UserId)
                .FirstOrDefault();

            if (data == null)
                return await Task.FromResult(new Response<User>(Message.NotFound("User")));
            else
                return await Task.FromResult(new Response<User>(data,Message.Success()));
        }

    }
}
