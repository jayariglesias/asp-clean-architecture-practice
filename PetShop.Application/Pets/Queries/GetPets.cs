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

namespace PetShop.Application.Pets.Queries
{
    public class GetPetsQuery : IRequest<Response<object>>
    {
    }

    public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, Response<object>>
    {
        private readonly IDataContext _context;

        public GetPetsQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Users
                    .Join(_context.Pets,
                        f => f.UserId,
                        s => s.UserId,
                        (f, s) =>
                        new
                        {
                            f.UserId,
                            s.PetId,
                            f.FirstName,
                            f.LastName,
                            s.Breed,
                            s.Birthdate
                        }
                    ).ToList();

            if (data == null)
                throw new ApiException("Data Not Found.");
            if (data.Count() == 0)
                return await Task.FromResult(new Response<object>(Message.NotFound("Data")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
      
    }

}
