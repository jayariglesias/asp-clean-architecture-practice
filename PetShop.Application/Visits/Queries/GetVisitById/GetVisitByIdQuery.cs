using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PetShop.Application.Visits.Dtos;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Visits.Queries.GetVisitById
{

    public class GetVisitByIdQuery : IRequest<Response<VisitDto>>
    {
        public int VisitId { get; set; }
    }

    public class GetVisitByIdHandler : IRequestHandler<GetVisitByIdQuery, Response<VisitDto>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetVisitByIdHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<VisitDto>> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Visits
                .Include(v => v.Pet)
                .ThenInclude(p => p.User)
                .Where(u => u.VisitId == request.VisitId)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<VisitDto>(data);

            if (data == null)
            {
                throw new ApiException(Message.NotFound("Visit"));
            }
            else
            {
                return await Task.FromResult(new Response<VisitDto>(result, Message.Success()));
            }
        }

    }
}
