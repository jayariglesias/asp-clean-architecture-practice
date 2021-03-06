using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PetClinic.Application.Visits.Dtos;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Visits.Queries.GetVisits
{
    public class GetVisitsQuery : IRequest<Response<IEnumerable<VisitDto>>>
    {
    }

    public class GetVisitsQueryHandler : IRequestHandler<GetVisitsQuery, Response<IEnumerable<VisitDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetVisitsQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<VisitDto>>> Handle(GetVisitsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Visits
                .Include(v => v.Pet)
                .ThenInclude(p => p.User)
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<VisitDto>>(data);

            if (data == null || data.Count() == 0)
            {
                throw new ApiException(Message.NotFound("Visits"));
            }
            else
            {
                return await Task.FromResult(new Response<IEnumerable<VisitDto>>(result, Message.Success()));
            }
        }
      
    }

}
