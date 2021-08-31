using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Common.DTO;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Auth.Command;

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
