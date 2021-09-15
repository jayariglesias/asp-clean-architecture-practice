using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Application.Auth.Commands;

namespace PetClinic.Api.Controllers
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
