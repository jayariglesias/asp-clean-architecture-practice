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
    public class UpdatePetCommand : IRequest<Response<object>>
    {
        public UpdatePetCommand(PetRequest e)
        {
            PetId = e.PetId;
            PetType = e.PetType;
            PetName = e.PetName;
            Breed = e.Breed;
            Birthdate = e.Birthdate;
        }

        public int PetId { get; set; }
        public int PetType { get; set; }
        public string PetName { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Response<object>>
    {
        private readonly IDataContext _context;
        public UpdatePetCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {

            var data = _context.Pets.FirstOrDefault(x => x.PetId == request.PetId);
            if (data == null)
                return await Task.FromResult(new Response<object>(Message.NotFound("User")));
            else
                data.PetName = request.PetName ?? data.PetName;
                data.PetType = Validate.Int(request.PetType) ? request.PetType : data.PetType;
                data.Breed = request.Breed ?? data.Breed;
                data.Birthdate = Validate.String(request.Birthdate.ToString()) ? request.Birthdate : data.Birthdate;

                _context.Pets.Update(data);
                _context.SaveChanges();

                if (data.PetId != 0)
                    return await Task.FromResult(new Response<object>(data, Message.Success()));
                else
                    return await Task.FromResult(new Response<object>(data, Message.Value("Failed to update data!")));
        }
      
    }
}
