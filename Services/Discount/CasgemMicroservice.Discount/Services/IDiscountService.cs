using CasgemMicroservice.Discount.Dtos;
using CasgemMicroservice.Discount.Models;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync();
        Task<Response<ResultDiscountDto>> GetByIdDiscountCouponAsync(int id);
        Task<Response<NoContent>> CreateDiscountCouponsAsync(CreateDiscountDto createDiscountDto);
        Task<Response<NoContent>> UpdateDiscountCouponsAsync(UpdateDiscountDto updateDiscountDto);
        Task<Response<NoContent>> DeleteDiscountCouponAsync(int id);
    }
}
