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
    public class SearchPetQuery : IRequest<Response<object>>
    {
        public SearchPetQuery(PetRequest e)
        {
            PetName = e.PetName;
        }

        public string PetName { get; set; }
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
            if (!Validate.String(request.PetName))
                return await Task.FromResult(new Response<object>(Message.FailedString("Pet name")));
           
            var data = _context.Pets.FirstOrDefault(x => 
                x.PetName.ToLower() == request.PetName.ToLower()
            );

            if (data == null) 
                return await Task.FromResult(new Response<object>(Message.NotFound("Pet")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
