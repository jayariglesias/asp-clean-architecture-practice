using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Domain.Entities;
using PetShop.Application.Common.Interfaces;
using PetShop.Infrastructure.Data;
using Newtonsoft.Json;
using PetShop.Application.Common.Validator;
using PetShop.Application.Common.DTO;
using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
