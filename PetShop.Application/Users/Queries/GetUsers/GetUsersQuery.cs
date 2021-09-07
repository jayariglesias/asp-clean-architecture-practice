using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Users.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Users.Queries.GetUsers
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
            {
                throw new ApiException(Message.NotFound("Users"));
            }
            else
            {
                return await Task.FromResult(new Response<IEnumerable<UserDto>>(result, Message.Success()));
            }
        }
    }

}
