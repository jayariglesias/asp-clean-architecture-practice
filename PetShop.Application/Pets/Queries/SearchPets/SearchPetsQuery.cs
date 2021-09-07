using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Pets.Dtos;
using AutoMapper;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Pets.Queries.SearchPets
{
    public class SearchPetQuery : IRequest<Response<IEnumerable<PetDto>>>
    {
        public int PetId { get; set; }
        public int PetType { get; set; }
        public string PetName { get; set; } = "";
        public string Breed { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";

    }

    public class SearchPetQueryHandler : IRequestHandler<SearchPetQuery, Response<IEnumerable<PetDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public SearchPetQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PetDto>>> Handle(SearchPetQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Pets
                .Include(u => u.User)
                .Include(p => p.Visits)
                .Where(u => 
                    u.PetId == request.PetId &&
                    u.PetType == request.PetType &&
                    u.PetName.ToLower() == request.PetName.ToLower() &&
                    u.Breed.ToLower() == request.Breed.ToLower() &&
                    u.User.FirstName.ToLower() == request.FirstName.ToLower() && 
                    u.User.MiddleName.ToLower() == request.MiddleName.ToLower() &&
                    u.User.LastName.ToLower() == request.LastName.ToLower()
                )
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<PetDto>>(data);

            if (data == null)
            {
                throw new ApiException(Message.NotFound("Pet"));
            }
            else
            {
                return await Task.FromResult(new Response<IEnumerable<PetDto>>(result, Message.Success()));
            }
        }
    }
}
