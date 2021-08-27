using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.Application.Common.DTO;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Validator;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Visits.Command;
using PetShop.Application.Visits.Queries;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ApiController
    {
        public VisitController()
        {
        }

        [HttpGet("index")]
        public async Task<Response<object>> GetAllVisits()
        {
            var query = new GetVisitsQuery();
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpGet("search/{id?}")]
        public async Task<Response<Visit>> GetVisit(int id)
        {
            var query = new GetVisitQuery(id);
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("search")]
        public async Task<Response<object>> SearchVisit(VisitRequest e)
        {
            var query = new SearchVisitQuery(e);
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("create")]
        public async Task<Response<object>> AddVisit(Visit e)
        {
            var command = new CreateVisitCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("update")]
        public async Task<Response<object>> UpdateVisit(VisitRequest e)
        {
            var command = new UpdateVisitCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpDelete("delete")]
        public async Task<Response<object>> DeleteVisit(VisitRequest e)
        {
            var command = new DeleteVisitCommand(e);
            var result = await Mediator.Send(command);
            return result;
        }
    }
}
