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
    public class CreateVisitCommand : IRequest<Response<object>>
    {
        public CreateVisitCommand(Visit e)
        {
            PetId = e.PetId;
            Notes = e.Notes;
            VisitType = e.VisitType;
            VisitDate = e.VisitDate;
        }

        public int PetId { get; set; }
        public string Notes { get; set; }
        public int VisitType { get; set; }
        public DateTime VisitDate { get; set; }

    }

    public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, Response<object>>
    {
        private readonly IDataContext _context;
        public CreateVisitCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {

            if(!Validate.Int(request.PetId)) return await Task.FromResult(new Response<object>(Message.FailedInt("Pet Id")));
            if(!Validate.String(request.Notes)) return await Task.FromResult(new Response<object>(Message.FailedString("Notes")));
            if(!Validate.Int(request.VisitType)) return await Task.FromResult(new Response<object>(Message.FailedInt("Visit type")));

            var verify = _context.Pets.FirstOrDefault(x => x.PetId == request.PetId);
            if(verify == null) return await Task.FromResult(new Response<object>(Message.Custom("You can`t create visit if pet is not registered.")));

            var data = new Visit
            {
                PetId = request.PetId,
                Notes = request.Notes,
                VisitType = request.VisitType,
                VisitDate = request.VisitDate
            };

            _context.Visits.Add(data);
            _context.SaveChanges();

            if (data.PetId == 0)
                return await Task.FromResult(new Response<object>(Message.Custom("Failed to save data!")));
            else
                return await Task.FromResult(new Response<object>(data, Message.Success()));
        }
    }
}
