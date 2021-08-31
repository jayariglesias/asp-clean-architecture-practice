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

namespace PetShop.Application.Visits.Queries
{

    public class GetVisitByIdQuery : IRequest<Response<object>>
    {
        public GetVisitByIdQuery(int id)
        {
            VisitId = id;
        }

        public int VisitId { get; set; }

    }

    public class GetVisitByIdHandler : IRequestHandler<GetVisitByIdQuery, Response<object>>
    {
        private readonly IDataContext _context;

        public GetVisitByIdHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Visits
                .Include(v => v.Pet)
                .ThenInclude(p => p.User)
                .Where(u => u.VisitId == request.VisitId)
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
                .FirstOrDefault();

            if (data == null)
                return await Task.FromResult(new Response<object>(Message.NotFound("Visit")));
            else
                return await Task.FromResult(new Response<object>(data,Message.Success()));
        }

    }
}
