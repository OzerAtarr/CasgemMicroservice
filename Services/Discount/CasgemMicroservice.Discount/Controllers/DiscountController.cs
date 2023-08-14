using CasgemMicroservice.Discount.Dtos;
using CasgemMicroservice.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            var values = await _discountService.GetAllDiscountCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var value = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountDto createDiscountDto)
        {
            var values = await _discountService.CreateDiscountCouponsAsync(createDiscountDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateDiscountCouponsAsync(updateDiscountDto);
            return Ok("Kupon Başarıyla Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }

    }
}
