using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Application.Common.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Message = message;
            Data = data;
        }

        public Response(string message, bool status = false)
        {
            Status = status;
            Message = message;
        }

        public bool Status { get; set; } = true;
        public string Message { get; set; }
        public object Errors { get; set; }
        public T Data { get; set; }
    }
}
