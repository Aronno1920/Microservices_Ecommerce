using Discount.Grpc.Protos;
using Discount.Grpc.Repository;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        ICouponRepository _couponRepository;
        ILogger<DiscountService> _logger;

        public DiscountService(ICouponRepository couponRepository, ILogger<DiscountService> logger)
        {
            _couponRepository = couponRepository;
            _logger = logger;
        }

        public override async Task<CouponRequest> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _couponRepository.GetDiscount(request.ProductId);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No discount found for the prodect"));
            }
            _logger.LogInformation("Discount is retived for {productName} with amount {amount}",coupon.ProductName,coupon.Amount);

            return new CouponRequest { ProductId = coupon.ProductId, ProductName=coupon.ProductName, Description=coupon.Description,Amount=coupon.Amount};
        }
    }
}
