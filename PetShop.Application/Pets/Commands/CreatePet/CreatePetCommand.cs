using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using PetShop.Domain.Entities;
using System;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<Response<object>>
    {
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

            var data = new Pet
            {
                UserId = request.UserId,
                PetName = request.PetName,
                PetType = request.PetType,
                Breed = request.Breed,
                Birthdate = request.Birthdate,
            };

            await _context.Pets.AddAsync(data);
            await _context.SaveChangesAsync(cancellationToken);

            if (data.PetId == 0 || data == null)
            {
                throw new ApiException(Message.Custom("Data was not saved!"));
            }
            else
            {
                return await Task.FromResult(new Response<object>(data, Message.Success()));
            }
        }
    }
}
