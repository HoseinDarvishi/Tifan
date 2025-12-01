using Grpc.Core;
using Tifan.Discount.IServices;
using Tifan.Discount.Wrappers;

namespace Tifan.Discount.grpcEndpoints
{
    public class GrpcDiscountService(IDiscountService service) : DiscountGrpc.DiscountGrpcBase
    {
        public override async Task<ResponseDiscount> AddDiscount(RequestAddDiscount request, ServerCallContext context)
        {
            var discount = await service.AddAsync(new CreateDiscount
            {
                Code = request.Code,
                Amount = request.Amount
            });

            return CastToResponse(discount);
        }

        public override async Task<ResponseDiscount> GetDiscountByCode(RequestGetDiscountByCode request, ServerCallContext context)
        {
            var discount = await service.GetAsync(request.Code);
            return CastToResponse(discount);
        }

        public override async Task<ResponseUseDiscount> UseDiscount(RequestUseDiscount request, ServerCallContext context)
        {
            await service.ExpireAsync(request.Code);
            return new ResponseUseDiscount { IsSuccess = true };
        }

        private ResponseDiscount CastToResponse(DiscountCodeVM discount)
            => new ResponseDiscount
            {
                Amount = discount.Amount,
                Code = discount.Code,
                Id = discount.Id.ToString(),
                IsExpire = discount.IsExpired
            };
    }
}
