using EcommerceMultiShop.Discount.Dtos;

namespace EcommerceMultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<IList<ResultCouponDto>> GetAllDiscountCouponDto();
        Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto);
        Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}
