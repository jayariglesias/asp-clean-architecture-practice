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

namespace PetShop.Application.Visits.Command
{
    public class UpdateVisitCommand : IRequest<Response<object>>
    {
        public UpdateVisitCommand(VisitRequest e)
        {
            VisitId = e.VisitId;
            PetId = e.PetId;
            Notes = e.Notes;
            VisitType = e.VisitType;
        }

        public int VisitId { get; set; }
        public int PetId { get; set; }
        public string Notes { get; set; }
        public int VisitType { get; set; }
    }

    public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand, Response<object>>
    {
        private readonly IDataContext _context;
        public UpdateVisitCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {

            var data = _context.Visits.FirstOrDefault(x => x.VisitId == request.VisitId);
            if (data == null)
                return await Task.FromResult(new Response<object>(Message.NotFound("Visit")));
            else
                data.VisitType = Validate.Int(request.VisitType) ? request.VisitType : data.VisitType;
                data.Notes = request.Notes ?? data.Notes;

                _context.Visits.Update(data);
                _context.SaveChanges();

                if (data.VisitId != 0)
                    return await Task.FromResult(new Response<object>(data, Message.Success()));
                else
                    return await Task.FromResult(new Response<object>(Message.Value("Failed to save data!")));
        }
      
    }
}
