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

namespace PetShop.Application.Pets.Queries
{

    public class GetPetByIdQuery : IRequest<Response<object>>
    {
        public GetPetByIdQuery(int id)
        {
            PetId = id;
        }

        public int PetId { get; set; }

    }

    public class GetPetByIdHandler : IRequestHandler<GetPetByIdQuery, Response<object>>
    {
        private readonly IDataContext _context;

        public GetPetByIdHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Pets
                .Include(u => u.User)
                .ThenInclude(p => p.Pets)
                .Include(p => p.Visits)
                .Where(u => u.PetId == request.PetId)
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
                .FirstOrDefault();

            if (data == null)
                return await Task.FromResult(new Response<object>(Message.NotFound("Pet")));
            else
                return await Task.FromResult(new Response<object>(data,Message.Success()));
        }

    }
}
