using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using PetShop.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PetShop.Application.Visits.Dtos;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Visits.Queries.SearchVisits
{
    public class SearchVisitQuery : IRequest<Response<IEnumerable<VisitDto>>>
    {
        public int VisitId { get; set; }
        public int PetId { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitFrom { get; set; }
        public DateTime VisitTo { get; set; }
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Notes { get; set; } = "";
        public string PetName { get; set; } = "";
    }

    public class SearchVisitQueryHandler : IRequestHandler<SearchVisitQuery, Response<IEnumerable<VisitDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public SearchVisitQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<VisitDto>>> Handle(SearchVisitQuery request, CancellationToken cancellationToken)
        {

            if (request.VisitFrom > request.VisitTo)
            {
                throw new ApiException(Message.Custom(Message.Custom("VisitFrom must not greater than VisitTo")));
            }


            var data = await _context.Visits
                        .Include(v => v.Pet)
                        .ThenInclude(p => p.User)
                        .Where(v =>
                            (request.VisitFrom != DateTime.MinValue || request.VisitTo != DateTime.MinValue) ?
                            (
                                v.VisitDate >= request.VisitFrom &&
                                v.VisitDate <= request.VisitTo
                            ) : (
                                v.Pet.PetName.ToLower().Contains(request.PetName.ToLower()) &&
                                v.Pet.User.FirstName.ToLower().Contains(request.FirstName.ToLower()) &&
                                v.Pet.User.MiddleName.ToLower().Contains(request.MiddleName.ToLower()) &&
                                v.Pet.User.LastName.ToLower().Contains(request.LastName.ToLower())
                            )
                        )
                        .ToListAsync();

            var result = _mapper.Map<IEnumerable<VisitDto>>(data);

            if (data == null || data.Count() == 0)
            {
                throw new ApiException(Message.NotFound("Visit"));
            }
            else
            {
                return await Task.FromResult(new Response<IEnumerable<VisitDto>>(result, Message.Success()));
            }
        }
    }
}
