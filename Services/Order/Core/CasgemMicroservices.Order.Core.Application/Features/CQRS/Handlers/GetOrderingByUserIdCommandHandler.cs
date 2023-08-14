using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Dtos.OrderingDtos;
using CasgemMicroservices.Order.Core.Application.Features.CQRS.Queries;
using CasgemMicroservices.Order.Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Features.CQRS.Handlers
{
    public class GetOrderByUserIdCommandHandler : IRequestHandler<GetOrderingByUserIdQueryRequest, List<ResultOrderDto>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetOrderByUserIdCommandHandler(IMapper mapper, IRepository<Ordering> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ResultOrderDto>> Handle(GetOrderingByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetOrdersById(x => x.UserID == request.Id);
            return _mapper.Map<List<ResultOrderDto>>(value);
        }
    }
}
