﻿using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PetShop.Application.Common.Dtos;
using PetShop.Application.Common.Interfaces;
using PetShop.Application.Common.Exceptions;
using PetShop.Application.Common.Wrappers;
using PetShop.Application.Common.Validator;
using PetShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Application.Visits.Commands
{

    public class DeleteVisitCommand : IRequest<Response<object>>
    {
        public DeleteVisitCommand(PetRequest e)
        {
            VisitId = e.VisitId;
        }

        public int VisitId { get; set; }

    }

    public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand, Response<object>>
    {
        private readonly IDataContext _context;

        public DeleteVisitCommandHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var data = _context.Visits.FirstOrDefault(x => x.VisitId == request.VisitId);
            if (data == null) return await Task.FromResult(new Response<object>(Message.NotFound("Visit")));

            _context.Visits.Remove(data);
            _context.SaveChanges();
            return await Task.FromResult(new Response<object>(Message.Success(),true));
        }

    }
}