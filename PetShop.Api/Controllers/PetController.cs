using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Validator;
using PetShop.Application.Common.DTO;
using PetShop.Application.Pets.Queries;
using PetShop.Application.Pets.Command;
using Microsoft.AspNetCore.Authorization;

namespace PetShop.Api.Controllers
{
    [Authorize]
    public class PetController : ApiController
    {
        
        public PetController()
        {
        }

        [HttpGet("index")]
        public async Task<Response<object>> GetAllPets()
        {
            var query = new GetPetsQuery();
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpGet("search/{id?}")]
        public async Task<Response<Pet>> GetPet(int id)
        {
            var query = new GetPetQuery(id);
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("search")]
        public async Task<Response<object>> SearchPet(PetRequest e)
        {
            var query = new SearchPetQuery(e);
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("create")]
        public async Task<Response<object>> AddPet (PetRequest e)
        {
            var command = new CreatePetCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("update")]
        public async Task<Response<object>> UpdatePet(PetRequest e)
        {
            var command = new UpdatePetCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpDelete("delete")]
        public async Task<Response<object>> DeletePet(PetRequest e)
        {
            var command = new DeletePetCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }
    }
}