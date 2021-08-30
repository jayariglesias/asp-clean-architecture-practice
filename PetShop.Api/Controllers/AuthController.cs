using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.Application.Common.DTO;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Validator;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Auth.Command;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PetShop.Api.Controllers
{

    public class AuthController : ApiController
    {

        public AuthController()
        {
        }

        [HttpPost("login")]
        public async Task<Response<object>> Login(UserRequest e)
        {
            var command = new LoginCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

    }
}
