using AutoMapper;
using CasgemMicroservice.Discount.Dtos;
using CasgemMicroservice.Discount.Models;

namespace CasgemMicroservice.Discount.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<DiscountCoupons, ResultDiscountDto>().ReverseMap();
            CreateMap<DiscountCoupons, CreateDiscountDto>().ReverseMap();
            CreateMap<DiscountCoupons, UpdateDiscountDto>().ReverseMap();
        }
    }
}
