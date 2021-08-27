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
using PetShop.Application.Common.Extensions;

namespace PetShop.Application.Visits.Queries {
    public class SearchVisitQuery : IRequest < Response < object >>
    {
        public SearchVisitQuery(VisitRequest e) {
            VisitId = e.VisitId;
            PetId = e.PetId;
            VisitType = e.VisitType;
            VisitFrom = e.VisitFrom;
            VisitTo = e.VisitTo;
            FirstName = LetterCase.ToLower(e.FirstName);
            MiddleName = LetterCase.ToLower(e.MiddleName);
            LastName = LetterCase.ToLower(e.LastName);
            Notes = LetterCase.ToLower(e.Notes);
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

public class SearchVisitQueryHandler : IRequestHandler < SearchVisitQuery, Response < object >>
{
    private readonly IDataContext _context;
    public SearchVisitQueryHandler(IDataContext context) {
        _context = context;
    }

        public async Task<Response< object >> Handle(SearchVisitQuery request, CancellationToken cancellationToken)
{
    if (!Validate.Int(request.VisitId))
        return await Task.FromResult(new Response < object > (Message.FailedString("Visit Id")));

        var data = _context.Pets
            .Join(_context.Visits,
                Pet => Pet.PetId,
                Visit => Visit.PetId,
                (Pet, Visit) =>
                    new { Pet, Visit }
            ).Join(_context.Users,
                combined => combined.Pet.UserId,
                User => User.UserId,
                (combined, user) => new
                {
                    user.FirstName,
                    user.LastName,
                    user.MiddleName,
                    combined.Pet.UserId,
                    combined.Pet.PetName,
                    combined.Pet.PetType,
                    combined.Visit.Notes,
                    combined.Visit.VisitType,
                    combined.Visit.VisitDate
                })
            .Where(d =>
                (
                    d.FirstName.ToLower().Contains(request.FirstName) ||
                    d.MiddleName.ToLower().Contains(request.MiddleName) ||
                    d.LastName.ToLower().Contains(request.LastName) ||
                    d.PetName.ToLower().Contains(request.MiddleName) ||
                    d.VisitType.Equals(request.VisitType)
                )
                && (d.VisitDate >= request.VisitFrom && d.VisitDate <= request.VisitTo)
            );

        if (data == null)
            return await Task.FromResult(new Response < object > (Message.NotFound("Visit")));
        else
            return await Task.FromResult(new Response < object > (data, Message.Success()));
}
    }
}
