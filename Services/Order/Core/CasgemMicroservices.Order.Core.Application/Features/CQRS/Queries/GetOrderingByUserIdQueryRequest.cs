using CasgemMicroservices.Order.Core.Application.Dtos.OrderingDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Features.CQRS.Queries
{
    public class GetOrderingByUserIdQueryRequest : IRequest<List<ResultOrderDto>>
    {

        public string Id { get; set; }
    }
}
