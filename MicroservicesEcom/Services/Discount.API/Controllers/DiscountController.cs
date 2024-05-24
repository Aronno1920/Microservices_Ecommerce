using CoreApiResponse;
using Discount.API.Models;
using Discount.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : BaseController
    {
        ICouponRepository _couponRepository;

        public DiscountController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Coupon),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiscount(string productId) {
            try
            {
                var coupon = await _couponRepository.GetDiscount(productId);
                return CustomResult(coupon);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDiscount([FromBody]Coupon coupon)
        {
            try
            {
                var isSaved = await _couponRepository.CreateDiscount(coupon);
                if(isSaved)
                {
                    return CustomResult("Coupon has been created", coupon);
                }
                else
                {
                    return CustomResult("Coupon not created", coupon,HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
        {
            try
            {
                var isModify = await _couponRepository.UpdateDiscount(coupon);
                if (isModify)
                {
                    return CustomResult("Coupon has been modified", coupon);
                }
                else
                {
                    return CustomResult("Coupon not modified", coupon, HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string proeuctId)
        {
            try
            {
                var isDeleted = await _couponRepository.DeleteDiscount(proeuctId);
                if (isDeleted)
                {
                    return CustomResult("Coupon has been deleted");
                }
                else
                {
                    return CustomResult("Coupon not deleted", HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
