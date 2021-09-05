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
            var data = _context.Pets
                .Include(u => u.User)
                .ThenInclude(p => p.Pets)
                .Include(p => p.Visits)
                .Select(p => new
                {
                    p.PetId,
                    p.PetName,
                    p.Breed,
                    p.PetType,
                    Owner = new
                    {
                        p.User.FirstName,
                        p.User.LastName,
                        p.User.MiddleName,
                        p.User.Username,
                        p.User.Email
                    },
                    Visit = p.Visits.Select(v => new
                    {
                        v.PetId,
                        v.VisitId,
                        v.VisitDate,
                        v.Notes
                    })
                })
                .ToList();

            if (data == null)
                throw new ApiException("Data Not Found.");
            if (data.Count() == 0)
                return await Task.FromResult(new Response<object>(Message.NotFound("Data")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
      
    }

}
