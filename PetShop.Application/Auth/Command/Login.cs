﻿using MediatR;
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
using Microsoft.Extensions.Configuration;

namespace PetShop.Application.Auth.Command
{
    public class LoginCommand : IRequest<Response<object>>
    {

        public LoginCommand(UserRequest e)
        {
            Username = e.Username;
            Password = e.Password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<object>>
    {
        private readonly IDataContext _context;
        private readonly IConfiguration _config;
        public LoginCommandHandler(IDataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<Response<object>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!Validate.String(request.Username)) return await Task.FromResult(new Response<object>(Message.FailedString("Username")));
            if (!Validate.String(request.Password)) return await Task.FromResult(new Response<object>(Message.FailedString("Password")));

            var data = _context.Users.FirstOrDefault(x =>
                x.Username == request.Username &&
                x.Password == request.Password
            );

            var cred = new AuthResponse(data, Token.Generate(data, _config));

            if (data == null)
                return await Task.FromResult(new Response<object>(Message.Value("Invalid Credentials!")));
            else
                return await Task.FromResult(new Response<object>(cred, Message.Success()));
        }
    }
}
