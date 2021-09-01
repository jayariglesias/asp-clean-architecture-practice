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
using System;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Application.Visits.Queries {
    public class SearchVisitQuery : IRequest<Response<object>>
    {
        public SearchVisitQuery(VisitRequest e) 
        {
            VisitId = e.VisitId;
            PetId = e.PetId;
            VisitType = e.VisitType;
            VisitFrom = e.VisitFrom;
            VisitTo = e.VisitTo;
            FirstName = e.FirstName ?? "";
            MiddleName = e.MiddleName ?? "";
            LastName = e.LastName ?? "";
            PetName = e.PetName ?? "";
            Notes = e.Notes ?? "";
        }

        public int VisitId { get; set; }
        public int PetId { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitFrom { get; set; }
        public DateTime VisitTo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public string PetName { get; set; }
    }

    public class SearchVisitQueryHandler : IRequestHandler<SearchVisitQuery, Response<object>>
    {
        private readonly IDataContext _context;
        public SearchVisitQueryHandler(IDataContext context) 
        {
            _context = context;
        }

        public async Task<Response< object >> Handle(SearchVisitQuery request, CancellationToken cancellationToken)
        {
                if (!Validate.Int(request.VisitId))
                    return await Task.FromResult(new Response<object>(Message.FailedString("Visit Id")));
                if(request.VisitFrom > request.VisitTo)
                    return await Task.FromResult(new Response<object>(Message.Custom("VisitFrom must not greater than VisitTo")));

                    var data = _context.Visits
                        .Include(v => v.Pet)
                        .ThenInclude(p => p.User)
                        .Where(v =>
                            (
                                v.Pet.PetName.ToLower() == request.PetName.ToLower() ||
                                v.Pet.User.FirstName.ToLower() == request.FirstName.ToLower() ||
                                v.Pet.User.MiddleName.ToLower() == request.MiddleName.ToLower() ||
                                v.Pet.User.LastName.ToLower() == request.LastName.ToLower()
                            ) ||
                            (
                                v.VisitDate >= request.VisitFrom && v.VisitDate <= request.VisitTo
                            )
                        )
                        .Select(v => new
                        {
                            v.VisitId,
                            v.PetId,
                            v.Pet.PetName,
                            v.Pet.PetType,
                            v.Pet.Breed,
                            v.Notes,
                            v.VisitDate,
                            Owner = new
                            {
                                v.Pet.User.FirstName,
                                v.Pet.User.LastName,
                                v.Pet.User.MiddleName,
                                v.Pet.User.Username,
                                v.Pet.User.Email
                            },
                        })
                        .ToList();

                if (data.Count == 0 || data == null)
                    return await Task.FromResult(new Response<object>(Message.NotFound("Visit")));
                else
                    return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
