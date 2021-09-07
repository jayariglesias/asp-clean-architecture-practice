using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Common.Exceptions;

namespace PetShop.Application.Visits.Commands.DeleteVisit
{

    public class DeleteVisitCommand : IRequest<Response<int>>
    {
        public int VisitId { get; set; }
    }

    public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand, Response<int>>
    {
        private readonly IDataContext _context;

        public DeleteVisitCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Visits.FirstOrDefaultAsync(x => x.VisitId == request.VisitId);
            if (data == null)
            {
                throw new ApiException(Message.Custom(Message.NotFound("Visit")));
            }

            _context.Visits.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(new Response<int>(Message.Success(),true));
        }

    }
}
