using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Tifan.Discount.Infra;
using Tifan.Discount.IServices;
using Tifan.Discount.Wrappers;

namespace Tifan.Discount.Services;

public class DiscountService(DiscountDbContext context, IMapper mapper) : IDiscountService
{
    public async Task<DiscountCodeVM> GetAsync(string code, CancellationToken ct = default)
    {
        var discount = await context.Discounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Code == code, ct);

        if (discount == null)
            throw new Exception("Discount Code Not Valid");

        return mapper.Map<DiscountCodeVM>(discount);
    }

    public async Task<DiscountCodeVM> GetNotExpireAsync(string code , CancellationToken ct = default)
    {
        var discount = await GetAsync(code, ct);
        if(discount.IsExpired)
            throw new Exception("Discount Code Is Expired !");

        return mapper.Map<DiscountCodeVM>(discount);
    }

    public async Task ExpireAsync(string code, CancellationToken ct = default)
        => await context.Discounts.Where(x => x.Code == code)
                 .ExecuteUpdateAsync(op => op.SetProperty(x => x.IsExpired, true), ct);
}