using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Dtos.AddressDtos;
using CasgemMicroservices.Order.Core.Application.Dtos.OrderDetailDtos;
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
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryRequest, ResultAddressDto>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetByIdAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<ResultAddressDto> Handle(GetByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultAddressDto>(result);
        }
    }
}
