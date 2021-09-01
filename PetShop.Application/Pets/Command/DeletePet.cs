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

namespace PetShop.Application.Pets.Queries
{

    public class DeletePetCommand: IRequest<Response<object>>
    {
        public DeletePetCommand(PetRequest e)
        {
            PetId = e.PetId;
        }

        public int PetId { get; set; }

    }

    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, Response<object>>
    {
        private readonly IDataContext _context;

        public DeletePetCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            var verify = _context.Visits.FirstOrDefault(x => x.PetId == request.PetId);
            if (verify != null) return await Task.FromResult(new Response<object>(Message.Custom("Failed! Pet is already in used in visit.")));

            var data = _context.Pets.FirstOrDefault(x => x.PetId == request.PetId);
            if (data == null) return await Task.FromResult(new Response<object>(Message.NotFound("Pet")));

            _context.Pets.Remove(data);
            _context.SaveChanges();
            return await Task.FromResult(new Response<object>(Message.Success(), true));
        }

    }
}
