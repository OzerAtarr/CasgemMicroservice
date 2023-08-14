using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservices.Order.Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Features.CQRS.Handlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingID);
            values.UserID = request.UserID;
            values.TotalPrice = request.TotalPrice;
            values.dateTime = request.dateTime;

            await _repository.UpdateAsync(values);
        }
    }
}
