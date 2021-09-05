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
    public class SearchPetQuery : IRequest<Response<object>>
    {
        public SearchPetQuery(PetRequest e)
        {
            PetId = e.PetId;
            PetType = e.PetType;
            PetName = e.PetName ?? "";
            Breed = e.Breed ?? "";
            FirstName = e.FirstName ?? "";
            MiddleName = e.MiddleName ?? "";
            LastName = e.LastName ?? "";
        }

        public int PetId { get; set; }
        public int PetType { get; set; }
        public string PetName { get; set; }
        public string Breed { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

    }

    public class SearchPetQueryHandler : IRequestHandler<SearchPetQuery, Response<object>>
    {
        private readonly IDataContext _context;
        public SearchPetQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(SearchPetQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Pets
                .Include(u => u.User)
                .ThenInclude(p => p.Pets)
                .Include(p => p.Visits)
                .Where(u => 
                    u.PetId == request.PetId ||
                    u.PetType == request.PetType ||
                    u.PetName.ToLower() == request.PetName.ToLower() ||
                    u.Breed.ToLower() == request.Breed.ToLower() ||
                    u.User.FirstName.ToLower() == request.FirstName.ToLower() ||
                    u.User.MiddleName.ToLower() == request.MiddleName.ToLower() ||
                    u.User.LastName.ToLower() == request.LastName.ToLower()
                )
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
                return await Task.FromResult(new Response<object>(Message.NotFound("Pet")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
