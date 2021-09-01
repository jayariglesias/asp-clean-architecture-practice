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
using Microsoft.EntityFrameworkCore;

namespace PetShop.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<Response<object>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Response<object>>
    {
        private readonly IDataContext _context;

        public GetUsersQueryHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Users
                .Include(u => u.Pets)
                .ThenInclude(p => p.Visits)
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
                    )
                    }
                )
                })
                .ToList();

            if (data == null || data.Count() == 0)
                return await Task.FromResult(new Response<object>(Message.NotFound("Users")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }

}
