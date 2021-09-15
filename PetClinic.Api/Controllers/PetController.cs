using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Application.Pets.Commands.CreatePet;
using PetClinic.Application.Pets.Commands.DeletePet;
using PetClinic.Application.Pets.Commands.UpdatePet;
using PetClinic.Application.Pets.Queries.SearchPets;
using PetClinic.Application.Pets.Queries.GetPetById;
using PetClinic.Application.Pets.Queries.GetPets;
using PetClinic.Application.Pets.Dtos;

namespace PetClinic.Api.Controllers
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