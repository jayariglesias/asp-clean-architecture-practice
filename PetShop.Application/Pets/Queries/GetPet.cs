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

namespace PetShop.Application.Pets.Queries
{

    public class GetPetQuery : IRequest<Response<Pet>>
    {
        public GetPetQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }

    public class GetPetHandler : IRequestHandler<GetPetQuery, Response<Pet>>
    {
        private readonly IDataContext _context;

        public GetPetHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<Pet>> Handle(GetPetQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Pets.FirstOrDefault(x => x.PetId == request.Id);
            if (data == null)
                return await Task.FromResult(new Response<Pet>(Message.NotFound("Pet")));
            else
                return await Task.FromResult(new Response<Pet>(data,Message.Success()));
        }

    }
}
