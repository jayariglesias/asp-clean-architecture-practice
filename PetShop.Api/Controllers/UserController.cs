﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.Application.Common.DTO;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Validator;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Users.Command;
using PetShop.Application.Users.Queries;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        public UserController()
        {
        }

        [HttpGet("index")]
        public async Task<Response<List<User>>> GetAllUsers()
        {
            var query = new GetUsersQuery();
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpGet("search/{id?}")]
        public async Task<Response<User>> GetUser(int id)
        {
            var query = new GetUserQuery(id);
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("search")]
        public async Task<Response<object>> SearchUser(UserRequest e)
        {
            var query = new SearchUserQuery(e);
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("create")]
        public async Task<Response<object>> AddUser(UserRequest e)
        {
            var command = new CreateUserCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("update")]
        public async Task<Response<object>> UpdateUser(UserRequest e)
        {
            var command = new UpdateUserCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpDelete("delete")]
        public async Task<Response<object>> DeleteUser(UserRequest e)
        {
            var command = new DeleteUserCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }
    }
}
