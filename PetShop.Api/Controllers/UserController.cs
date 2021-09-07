using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Users.Commands.CreateUser;
using PetShop.Application.Users.Commands.DeleteUser;
using PetShop.Application.Users.Commands.UpdateUser;
using PetShop.Application.Users.Queries.SearchUsers;
using PetShop.Application.Users.Queries.GetUserById;
using PetShop.Application.Users.Queries.GetUsers;
using PetShop.Application.Users.Dtos;

namespace PetShop.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        public UserController()
        {
        }

        [HttpGet("index")]
        public async Task<Response<IEnumerable<UserDto>>> GetAllUsers()
        {
            return await Mediator.Send(new GetUsersQuery());
        }

        [HttpGet("search/{id?}")]
        public async Task<Response<UserDto>> GetUserById(int id)
        {
            return await Mediator.Send(new GetUserByIdQuery { UserId = id }); 
        }

        [HttpPost("search")]
        public async Task<Response<IEnumerable<UserDto>>> SearchUser(SearchUserQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<Response<object>> AddUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("update")]
        public async Task<Response<object>> UpdateUser(UpdateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("delete")]
        public async Task<Response<int>> DeleteUser(DeleteUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
