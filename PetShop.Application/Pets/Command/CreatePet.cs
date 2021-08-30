using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.DTO;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Validator;
using PetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace PetShop.Application.Pets.Command
{
    public class CreatePetCommand : IRequest<Response<object>>
    {
        public CreatePetCommand(PetRequest e)
        {
            UserId = e.UserId;
            PetType = e.PetType;
            PetName = e.PetName;
            Breed = e.Breed;
            Birthdate = e.Birthdate;
        }

        public int UserId { get; set; }
        public int PetType { get; set; }
        public string PetName { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; } 
    }

    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Response<object>>
    {
        private readonly IDataContext _context;
        public CreatePetCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {

            if(!Validate.Int(request.UserId)) return await Task.FromResult(new Response<object>(Message.FailedInt("User Id")));
            if(!Validate.String(request.PetName)) return await Task.FromResult(new Response<object>(Message.FailedString("Pet name")));
            if(!Validate.Int(request.PetType)) return await Task.FromResult(new Response<object>(Message.FailedInt("Pet type")));
            if(!Validate.String(request.Breed)) return await Task.FromResult(new Response<object>(Message.FailedString("Breed")));

            var verify = _context.Users.FirstOrDefault(x => x.UserId == request.UserId);
            if (verify == null) return await Task.FromResult(new Response<object>(Message.Value("User not registered yet.")));

            var data = new Pet
            {
                UserId= request.UserId,
                PetName = request.PetName,
                PetType = request.PetType,
                Breed = request.Breed,
                Birthdate = request.Birthdate,
            };

            _context.Pets.Add(data);
            _context.SaveChanges();

            if (data.PetId != 0)
                return await Task.FromResult(new Response<object>(data, Message.Success()));
            else
                return await Task.FromResult(new Response<object>(Message.Value("Failed to save data!")));
        }
    }
}
