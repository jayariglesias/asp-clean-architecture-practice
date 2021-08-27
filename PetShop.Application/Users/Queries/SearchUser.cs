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

namespace PetShop.Application.Users.Queries
{
    public class SearchUserQuery : IRequest<Response<object>>
    {
        public SearchUserQuery(UserRequest e)
        {
            FirstName = e.FirstName;
            LastName = e.LastName;
        }

        public string FirstName { get; set; }
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
            if (!Validate.String(request.FirstName))
                return await Task.FromResult(new Response<object>(Message.FailedString("First name")));
            if (!Validate.String(request.LastName))
                return await Task.FromResult(new Response<object>(Message.FailedString("Last name")));
           
            var data = _context.Users.FirstOrDefault(x => 
                x.FirstName.ToLower() == request.FirstName.ToLower() && 
                x.LastName.ToLower() == request.LastName.ToLower()
            );

            if (data == null) 
                return await Task.FromResult(new Response<object>(Message.NotFound("User")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
