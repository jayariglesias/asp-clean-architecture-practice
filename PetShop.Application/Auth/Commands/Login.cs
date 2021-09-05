﻿using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using PetShop.Domain.Entities;
using Microsoft.Extensions.Configuration;
using PetShop.Application.Common.Validator;
using PetShop.Application.Common.Dtos;
using PetShop.Application.Auth.Dtos;

namespace PetShop.Application.Auth.Commands
{
    public class LoginCommand : IRequest<Response<object>>
    {
        public LoginCommand(PetRequest e)
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
        private readonly IToken _token;

        public LoginCommandHandler(IDataContext context, IToken token)
        {
            _context = context;
            _token = token;
        }

        public async Task<Response<object>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!Validate.String(request.Username)) return await Task.FromResult(new Response<object>(Message.FailedString("Username")));
            if (!Validate.String(request.Password)) return await Task.FromResult(new Response<object>(Message.FailedString("Password")));

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
                var token = await _token.Create(data, 60);
                if(token != null)
                {
                    var credentials = new loginDto(data, token); ;
                    return await Task.FromResult(new Response<object>(credentials, Message.Success()));
                }
                return await Task.FromResult(new Response<object>(Message.Custom("Failed! Can`t Generate a Token.")));
            }
        }
    }
}