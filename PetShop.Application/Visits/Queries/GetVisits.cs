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
            var data = _context.Visits
                .Include(v => v.Pet)
                .ThenInclude(p => p.User)
                .Select(v => new
                {
                    v.VisitId,
                    v.PetId,
                    v.Pet.PetName,
                    v.Pet.PetType,
                    v.Pet.Breed,
                    v.Notes,
                    v.VisitDate,
                    Owner = new
                    {
                        v.Pet.User.FirstName,
                        v.Pet.User.LastName,
                        v.Pet.User.MiddleName,
                        v.Pet.User.Username,
                        v.Pet.User.Email
                    },
                })
                .ToList();

            if (data.Count() == 0 || data == null)
                return await Task.FromResult(new Response<object>(Message.NotFound("Data")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
      
    }

}
