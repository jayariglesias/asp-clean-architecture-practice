using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PetShop.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var responseModel = new Response<object>() {
                    Status = false,
                    Message = "Failed!", 
                    Errors = error?.Message 
                };
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ApiException e: // Custom
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Message;
                    break;
                    case ValidationException e: // Custom
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                    break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                }

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var json = JsonConvert.SerializeObject(responseModel, serializerSettings);
                await response.WriteAsync(json);
            }
        }

    }
}
