using CasgemMicroservices.Order.Core.Application.Dtos.AddressDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Features.CQRS.Queries
{
    public class GetByIdAddressQueryRequest : IRequest<ResultAddressDto>
    {
        public int Id { get; set; }

        public GetByIdAddressQueryRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
