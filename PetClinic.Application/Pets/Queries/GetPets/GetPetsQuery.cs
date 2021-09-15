using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Pets.Dtos;
using AutoMapper;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Pets.Queries.GetPets
{
    public class GetPetsQuery : IRequest<Response<IEnumerable<PetDto>>>
    {
    }

    public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, Response<IEnumerable<PetDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetPetsQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PetDto>>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Pets
                .Include(u => u.User)
                .Include(p => p.Visits)
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<PetDto>>(data);

            if (data == null || data.Count() == 0)
            {
                throw new ApiException(Message.NotFound("Data"));
            }
            else
            {
                return await Task.FromResult(new Response<IEnumerable<PetDto>>(result, Message.Success()));
            }
        }
      
    }

}
