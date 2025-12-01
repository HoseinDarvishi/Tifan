using Mapster;
using Tifan.Discount.Models;
using Tifan.Discount.Wrappers;

namespace Tifan.Discount.Services;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<DiscountCodeVM, DiscountCode>
            .NewConfig()
            .TwoWays();
    }
}
