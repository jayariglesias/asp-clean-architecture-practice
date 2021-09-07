using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Visits.Commands.CreateVisit;
using PetShop.Application.Visits.Commands.DeleteVisit;
using PetShop.Application.Visits.Commands.UpdateVisit;
using PetShop.Application.Visits.Queries.SearchVisits;
using PetShop.Application.Visits.Queries.GetVisitById;
using PetShop.Application.Visits.Queries.GetVisits;
using PetShop.Application.Visits.Dtos;

namespace PetShop.Api.Controllers
{
    [Authorize]
    public class VisitController : ApiController
    {
        public VisitController()
        {
        }

        [HttpGet("index")]
        public async Task<Response<IEnumerable<VisitDto>>> GetAllVisits()
        {
            return await Mediator.Send(new GetVisitsQuery());
        }

        [HttpGet("search/{id?}")]
        public async Task<Response<VisitDto>> GetVisitById(int id)
        {
            return await Mediator.Send(new GetVisitByIdQuery { VisitId = id});
        }

        [HttpPost("search")]
        public async Task<Response<IEnumerable<VisitDto>>> SearchVisit(SearchVisitQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<Response<object>> AddVisit(CreateVisitCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("update")]
        public async Task<Response<object>> UpdateVisit(UpdateVisitCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("delete")]
        public async Task<Response<int>> DeleteVisit(DeleteVisitCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
