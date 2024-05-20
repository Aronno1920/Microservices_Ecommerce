using Basket.API.Models;
using Basket.API.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string userName)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(userName);
                if (basket == null)
                {
                    return CustomResult("Basket loaded successful", basket);
                }
                else
                {
                    return CustomResult("No data found", basket);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                await _basketRepository.UpdateBasket(basket);
                return CustomResult("Basket modificed complete", basket);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                await _basketRepository.DeleteBasket(basket.UserName);
                return CustomResult("Basket deleted successfully", basket);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
