using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Application.Common.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Message = message;
            Result = data;
        }

        public Response(string message, bool status = false)
        {
            Status = status;
            Message = message;
        }

        public bool Status { get; set; } = true;
        public string Message { get; set; }
        public object Errors { get; set; }
        public T Result { get; set; }
    }
}
