using Tifan.Discount.Wrappers;

namespace Tifan.Discount.IServices;

public interface IDiscountService
{
    Task<DiscountCodeVM> AddAsync(CreateDiscount discount);
    Task ExpireAsync(string code, CancellationToken ct = default);
    Task<DiscountCodeVM> GetAsync(string code, CancellationToken ct = default);
    Task<DiscountCodeVM> GetNotExpireAsync(string code, CancellationToken ct = default);
}
