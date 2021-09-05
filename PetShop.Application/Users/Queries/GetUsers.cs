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
using PetShop.Application.Users.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace PetShop.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<Response<IEnumerable<UserDto>>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Response<IEnumerable<UserDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Users
                .Include(u => u.Pets)
                .ThenInclude(p => p.Visits)
                .ToListAsync();
            var result = _mapper.Map<IEnumerable<UserDto>>(data);

            if (result == null || result.Count() == 0)
                return await Task.FromResult(new Response<IEnumerable<UserDto>>(Message.NotFound("Users")));
            else
                return await Task.FromResult(new Response<IEnumerable<UserDto>>(result, Message.Success()));

            /* .Include(u => u.Pets)
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
             .ToListAsync();
            */


        }
    }

}
