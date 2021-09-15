using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Application.Visits.Commands.CreateVisit;
using PetClinic.Application.Visits.Commands.DeleteVisit;
using PetClinic.Application.Visits.Commands.UpdateVisit;
using PetClinic.Application.Visits.Queries.SearchVisits;
using PetClinic.Application.Visits.Queries.GetVisitById;
using PetClinic.Application.Visits.Queries.GetVisits;
using PetClinic.Application.Visits.Dtos;

namespace PetClinic.Api.Controllers
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
