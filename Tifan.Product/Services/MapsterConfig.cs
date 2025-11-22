using Mapster;
using Tifan.Product.Models;
using Tifan.Product.Wrappers.Category;
using Tifan.Product.Wrappers.Product;

namespace Tifan.Product.Services;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CategoryVM, Category>
            .NewConfig()
            .TwoWays();

        TypeAdapterConfig<ProductVM ,Models.Product>
            .NewConfig()
            .TwoWays();
    }
}