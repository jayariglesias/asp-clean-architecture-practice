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

namespace PetShop.Application.Users.Queries
{

    public class GetUserQuery : IRequest<Response<User>>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }

    public class GetUserHandler : IRequestHandler<GetUserQuery, Response<User>>
    {
        private readonly IDataContext _context;

        public GetUserHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Users.FirstOrDefault(x => x.UserId == request.Id);
            if (data == null)
                return await Task.FromResult(new Response<User>(Message.NotFound("User")));
            else
                return await Task.FromResult(new Response<User>(Message.Success()));
        }

    }
}
