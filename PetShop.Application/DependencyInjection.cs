using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using PetShop.Application.Common.Interfaces;
using System.Reflection;
using PetShop.Application.Common.DTO;
using PetShop.Domain.Entities;
using MediatR;

namespace PetShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
