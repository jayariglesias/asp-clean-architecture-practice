using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Domain.Entities;
using System;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Visits.Commands.CreateVisit
{
    public class CreateVisitCommand : IRequest<Response<object>>
    {
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

            var data = new Visit
            {
                PetId = request.PetId,
                Notes = request.Notes,
                VisitType = request.VisitType,
                VisitDate = request.VisitDate
            };

            await _context.Visits.AddAsync(data);
            await _context.SaveChangesAsync(cancellationToken);

            if (data.PetId == 0)
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
