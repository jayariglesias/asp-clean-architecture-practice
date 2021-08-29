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

namespace PetShop.Application.Visits.Queries
{

    public class GetVisitQuery : IRequest<Response<Visit>>
    {
        public GetVisitQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }

    public class GetVisitHandler : IRequestHandler<GetVisitQuery, Response<Visit>>
    {
        private readonly IDataContext _context;

        public GetVisitHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<Visit>> Handle(GetVisitQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Visits.FirstOrDefault(x => x.VisitId == request.Id);
            if (data == null)
                return await Task.FromResult(new Response<Visit>(Message.NotFound("Visit")));
            else
                return await Task.FromResult(new Response<Visit>(data,Message.Success()));
        }

    }
}
