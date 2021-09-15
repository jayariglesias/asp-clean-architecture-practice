using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PetClinic.Application.Common.Interfaces;
using PetClinic.Application.Common.Wrappers;
using PetClinic.Application.Common.Exceptions;

namespace PetClinic.Application.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommand : IRequest<Response<object>>
    {
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
            {
                throw new ApiException(Message.Custom(Message.NotFound("Visit")));
            }
            else
            {
                data.VisitType = request.VisitType.ToString() != string.Empty ? request.VisitType : data.VisitType;
                data.Notes = request.Notes ?? data.Notes;
                
                await _context.SaveChangesAsync(cancellationToken);

                if (data.VisitId == 0)
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
