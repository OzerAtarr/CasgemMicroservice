using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Dtos.OrderDetailDtos;
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

    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<ResultOrderDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Ordering> _repository;

        public GetAllOrderingQueryHandler(IMapper mapper, IRepository<Ordering> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ResultOrderDto>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultOrderDto>>(values);
        }
    }
}