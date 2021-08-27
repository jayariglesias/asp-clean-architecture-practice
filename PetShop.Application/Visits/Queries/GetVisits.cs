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

namespace PetShop.Application.Visits.Queries
{
    public class GetVisitsQuery : IRequest<Response<object>>
    {
    }

    public class GetVisitsQueryHandler : IRequestHandler<GetVisitsQuery, Response<object>>
    {
        private readonly IDataContext _context;

        public GetVisitsQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(GetVisitsQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Pets
                    .Join(_context.Visits,
                        pet => pet.PetId,
                        visit => visit.PetId,
                        (pet, visit) =>
                        new
                        {
                            visit.VisitId,
                            visit.PetId,
                            pet.PetName,
                            pet.Breed,
                            pet.Birthdate,
                            visit.Notes,
                            visit.VisitDate
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
