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
    public class GetUsersQuery : IRequest<Response<List<User>>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Response<List<User>>>
    {
        private readonly IDataContext _context;

        public GetUsersQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Users.ToList();
            
            if (data == null)
                throw new ApiException("Data Not Found.");
            if (data.Count() == 0)
                return await Task.FromResult(new Response<List<User>>(Message.NotFound("Users")));
            else
                return await Task.FromResult(new Response<List<User>>(data, Message.Success()));
        }
      
    }

}
