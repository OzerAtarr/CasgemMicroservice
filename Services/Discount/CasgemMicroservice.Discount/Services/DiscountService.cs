using AutoMapper;
using CasgemMicroservice.Discount.Context;
using CasgemMicroservice.Discount.Dtos;
using CasgemMicroservice.Discount.Models;
using CasgemMicroservice.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        private readonly IMapper _mapper;
        public DiscountService(DapperContext dapperContext, IMapper mapper)
        {
            _dapperContext = dapperContext;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateDiscountCouponsAsync(CreateDiscountDto createDiscountDto)
        {
            var createCoupon = _mapper.Map<DiscountCoupons>(createDiscountDto);
            createDiscountDto.CreateTime = DateTime.Now;

            await _dapperContext.DiscountCouponses.AddAsync(createCoupon);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(201);
            
        }

        public async Task<Response<NoContent>> DeleteDiscountCouponAsync(int id)
        {
            var result = await _dapperContext.DiscountCouponses.FindAsync(id);
            if(result == null)
            {
                return Response<NoContent>.Fail("Silinecek Kupon Bulunamadı", 404);
            }
            _dapperContext.DiscountCouponses.Remove(result);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync()
        {
            var values = await _dapperContext.DiscountCouponses.ToListAsync();
            return Response<List<ResultDiscountDto>>.Success(_mapper.Map<List<ResultDiscountDto>>(values), 200);
        }

        public async Task<Response<ResultDiscountDto>> GetByIdDiscountCouponAsync(int id)
        {
            var result = await _dapperContext.DiscountCouponses.FindAsync(id);
            return Response<ResultDiscountDto>.Success(_mapper.Map<ResultDiscountDto>(result), 200);
        }

        public async Task<Response<NoContent>> UpdateDiscountCouponsAsync(UpdateDiscountDto updateDiscountDto)
        {
            var existingResponse = await _dapperContext.DiscountCouponses.FindAsync(updateDiscountDto.DiscountCouponID);
            if(existingResponse == null)
            {
                return Response<NoContent>.Fail("Güncellenecek Kupon Bulunamadı", 404);
            }
            _mapper.Map(updateDiscountDto, existingResponse);
            _dapperContext.DiscountCouponses.Update(existingResponse);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}
