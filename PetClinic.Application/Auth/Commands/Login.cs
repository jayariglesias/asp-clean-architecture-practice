using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Application.Auth.Dtos;

namespace PetClinic.Application.Auth.Commands
{
    public class LoginCommand : IRequest<Response<object>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<object>>
    {
        private readonly IDataContext _context;
        private readonly IToken _token;

        public LoginCommandHandler(IDataContext context, IToken token)
        {
            _context = context;
            _token = token;
        }

        public async Task<Response<object>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //if (!Validate.String(request.Username)) return await Task.FromResult(new Response<object>(Message.FailedString("Username")));
            //if (!Validate.String(request.Password)) return await Task.FromResult(new Response<object>(Message.FailedString("Password")));

            var data = _context.Users.FirstOrDefault(x =>
                x.Username == request.Username &&
                x.Password == request.Password
            );

            if (data == null)
            {
                return await Task.FromResult(new Response<object>(Message.Custom("Invalid Credentials!")));
            }
            else
            {
                var token = await _token.Create(data, 3600);
                if(token != null)
                {
                    var credentials = new LoginDto(data, token); ;
                    return await Task.FromResult(new Response<object>(credentials, Message.Success()));
                }
                return await Task.FromResult(new Response<object>(Message.Custom("Failed! Can`t Generate a Token.")));
            }
        }
    }
}
