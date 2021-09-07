using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Pets.Dtos;
using AutoMapper;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Pets.Queries.GetPetById
{

    public class GetPetByIdQuery : IRequest<Response<PetDto>>
    {
        public int PetId { get; set; }
    }

    public class GetPetByIdHandler : IRequestHandler<GetPetByIdQuery, Response<PetDto>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetPetByIdHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<PetDto>> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Pets
                .Include(u => u.User)
                .Include(p => p.Visits)
                .Where(u => u.PetId == request.PetId)
                .FirstOrDefaultAsync();
            
            var result = _mapper.Map<PetDto>(data);

            if (data == null)
            {
                throw new ApiException(Message.NotFound("Pet"));
            }
            else
            {
                return await Task.FromResult(new Response<PetDto>(result, Message.Success()));
            }
        }

    }
}
