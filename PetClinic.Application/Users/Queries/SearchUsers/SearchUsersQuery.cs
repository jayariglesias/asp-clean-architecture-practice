using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Users.Dtos;
using AutoMapper;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Users.Queries.SearchUsers
{
    public class SearchUserQuery : IRequest<Response<IEnumerable<UserDto>>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, Response<IEnumerable<UserDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public SearchUserQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UserDto>>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Users
                .Include(u => u.Pets)
                .ThenInclude(p => p.Visits)
                .Where(u =>
                    u.FirstName.ToLower().Contains(request.FirstName.ToLower()) && 
                    u.LastName.ToLower().Contains(request.LastName.ToLower())
                )
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
