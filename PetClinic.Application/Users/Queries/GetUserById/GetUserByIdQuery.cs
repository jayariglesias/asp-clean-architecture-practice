using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetClinic.Application.Users.Dtos;
using AutoMapper;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Response<UserDto>>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<UserDto>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Users
                .Include(u => u.Pets)
                .ThenInclude(p => p.Visits)
                .Where(u => u.UserId == request.UserId)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<UserDto>(data);

            if (result == null)
            {
                throw new ApiException(Message.NotFound("User"));
            }
            else
            {
                return await Task.FromResult(new Response<UserDto>(result, Message.Success()));
            }
        }

    }
}
