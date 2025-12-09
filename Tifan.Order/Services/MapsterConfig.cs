using Mapster;
using Tifan.Order.Models;
using Tifan.Order.Wrappers;

namespace Tifan.Order.Services
{
    public class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<AddOrderItem, OrderItem>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<AddOrder, Models.Order>
                .NewConfig()
                .TwoWays();
        }
    }
}
