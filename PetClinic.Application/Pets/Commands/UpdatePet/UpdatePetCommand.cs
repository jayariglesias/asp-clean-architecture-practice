using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using System;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommand : IRequest<Response<object>>
    {
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
            {
                throw new ApiException(Message.NotFound("Pet"));
            }
            else
            {
                data.PetName = request.PetName ?? data.PetName;
                data.Breed = request.Breed ?? data.Breed;
                data.PetType = request.PetType.ToString() != string.Empty ? request.PetType : data.PetType;
                data.Birthdate = request.Birthdate != DateTime.MinValue ? request.Birthdate : data.Birthdate;
                await _context.SaveChangesAsync(cancellationToken);
    
                if (data.PetId == 0 || data == null)
                {
                    throw new ApiException(Message.Custom("Data did not update in the database!"));
                }
                else
                {
                    return await Task.FromResult(new Response<object>(data, Message.Success()));
                }

            }
        }

    }
}
