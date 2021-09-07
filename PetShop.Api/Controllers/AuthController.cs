using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Auth.Commands;

namespace PetShop.Api.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController()
        {
        }

        [HttpPost("login")]
        public async Task<Response<object>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
