using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Dtos.AddressDtos;
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
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Address
            {
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserID = request.UserID,
            };
            return _repository.CreateAsync(values);
        }
    }
}
