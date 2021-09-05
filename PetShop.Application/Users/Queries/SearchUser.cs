using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Dtos;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Validator;
using PetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Application.Users.Queries
{
    public class SearchUserQuery : IRequest<Response<object>>
    {
   
    public SearchUserQuery(PetRequest e)
    {
        FirstName = e.FirstName ?? "";
        LastName = e.LastName ?? "";
        MiddleName = e.MiddleName ?? "";
    }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, Response<object>>
    {
        private readonly IDataContext _context;
        public SearchUserQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {

            var data = _context.Users
                .Include(u => u.Pets)
                .ThenInclude(p => p.Visits)
                .Where(u =>
                    u.FirstName.ToLower() == request.FirstName.ToLower() ||
                    u.LastName.ToLower() == request.LastName.ToLower()
                )
                .Select(u => new
                {
                    u.UserId,
                    u.FirstName,
                    u.LastName,
                    u.Username,
                    u.Email,
                    Pets = u.Pets.Select(p => new
                    {
                        p.PetId,
                        p.PetName,
                        p.Birthdate,
                        Visits = p.Visits.Select(v => new
                        {
                            v.PetId,
                            v.VisitId,
                            v.VisitDate,
                            v.Notes
                        }
                    )}
                )})
                .ToList();
                

            if (data == null) 
                return await Task.FromResult(new Response<object>(Message.NotFound("User")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
