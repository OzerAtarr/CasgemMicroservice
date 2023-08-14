using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservices.Order.Core.Application.Dtos.OrderingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ResultOrderDto, Ordering>().ReverseMap();
            CreateMap<CreateOrderDto, Ordering>().ReverseMap();
            CreateMap<UpdateOrderDto, Ordering>().ReverseMap();
        }
    }
}
