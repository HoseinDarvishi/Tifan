using Mapster;
using Tifan.Basket.Wrappers;
using TifanBasket.Models;

namespace Tifan.Basket.Services;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<BasketItemVM, BasketItem>
            .NewConfig()
            .TwoWays();

        TypeAdapterConfig<BasketVM, TifanBasket.Models.Basket>
            .NewConfig()
            .TwoWays();
    }
}
