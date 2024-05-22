using AutoMapper;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;
using Discount.Grpc.Repository;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        ICouponRepository _couponRepository;
        ILogger<DiscountService> _logger;
        IMapper _mapper;

        public DiscountService(ICouponRepository couponRepository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponRequest> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _couponRepository.GetDiscount(request.ProductId);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No discount found for the prodect"));
            }
            _logger.LogInformation("Discount is retived for {productName} with amount {amount}",coupon.ProductName,coupon.Amount);

            //return new CouponRequest { ProductId = coupon.ProductId, ProductName=coupon.ProductName, Description=coupon.Description,Amount=coupon.Amount};

            return _mapper.Map<CouponRequest>(coupon);
        }

        public override async Task<CouponRequest> CreateDiscount(CouponRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            bool isCreated= await _couponRepository.CreateDiscount(coupon);
            
            if (isCreated)
            {
                _logger.LogInformation("Discount is created for {ProductName}", coupon.ProductName);
            }
            else
            {
                _logger.LogInformation("Discount is create failed for {ProductName}", coupon.ProductName);
            }

            return _mapper.Map<CouponRequest>(coupon);
        }

        public override async Task<CouponRequest> UpdateDiscount(CouponRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            bool isModified = await _couponRepository.UpdateDiscount(coupon);

            if (isModified)
            {
                _logger.LogInformation("Discount is modified for {ProductName}", coupon.ProductName);
            }
            else
            {
                _logger.LogInformation("Discount is modify failed for {ProductName}", coupon.ProductName);
            }

            return _mapper.Map<CouponRequest>(coupon);
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var isDeleted = await _couponRepository.DeleteDiscount(request.ProductId);
            if (isDeleted)
            {
                _logger.LogInformation("Discount is deleted");
            }
            else
            {
                _logger.LogInformation("Discount is delete failed");
            }

            return new DeleteDiscountResponse()
            {
                Success = isDeleted
            };
        }
    }
}
