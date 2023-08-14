using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Dtos.AddressDtos;
using CasgemMicroservices.Order.Core.Application.Dtos.OrderDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Mappings
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<ResultOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailDto, OrderDetail>().ReverseMap();
        }
    }
}
