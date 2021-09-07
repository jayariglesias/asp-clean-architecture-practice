using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Pets.Commands.DeletePet
{

    public class DeletePetCommand: IRequest<Response<int>>
    {
        public int PetId { get; set; }
    }

    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, Response<int>>
    {
        private readonly IDataContext _context;

        public DeletePetCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {

            var data = await _context.Pets.FirstOrDefaultAsync(x => x.PetId == request.PetId);
            if (data == null)
            {
                throw new ApiException(Message.NotFound("Pet"));
            }

            var verify = await _context.Visits.FirstOrDefaultAsync(x => x.PetId == request.PetId);
            if (verify != null)
            {
                throw new ApiException(Message.Custom("Pet is already in used in visit."));
            }

            _context.Pets.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(new Response<int>(Message.Success(), true));
        }

    }
}
