using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Pets.Commands.CreatePet;
using PetShop.Application.Pets.Commands.DeletePet;
using PetShop.Application.Pets.Commands.UpdatePet;
using PetShop.Application.Pets.Queries.SearchPets;
using PetShop.Application.Pets.Queries.GetPetById;
using PetShop.Application.Pets.Queries.GetPets;
using PetShop.Application.Pets.Dtos;

namespace PetShop.Api.Controllers
{
    [Authorize]
    public class PetController : ApiController
    {
        
        public PetController()
        {
        }

        [HttpGet("index")]
        public async Task<Response<IEnumerable<PetDto>>> GetAllPets()
        {
            return await Mediator.Send(new GetPetsQuery());
        }

        [HttpGet("search/{id?}")]
        public async Task<Response<PetDto>> GetPetById(int id)
        {
            return await Mediator.Send(new GetPetByIdQuery { PetId = id });
        }

        [HttpPost("search")]
        public async Task<Response<IEnumerable<PetDto>>> SearchPet(SearchPetQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<Response<object>> AddPet (CreatePetCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("update")]
        public async Task<Response<object>> UpdatePet(UpdatePetCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("delete")]
        public async Task<Response<int>> DeletePet(DeletePetCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}