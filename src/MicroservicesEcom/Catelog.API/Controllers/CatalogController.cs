using Catelog.API.Interfaces.Manager;
using Catelog.API.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace Catelog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : BaseController
    {
        IProductManager _productManager;
        public CatalogController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration = 60)]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productManager.GetAll();
                return CustomResult(products);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult GetProductById(string id)
        {
            try
            {
                var product = _productManager.GetById(id);
                return CustomResult("Product found",product, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                product.Id = ObjectId.GenerateNewId().ToString();
                bool isSaved = _productManager.Add(product);

                if (isSaved)
                {
                    return CustomResult("Product has been save successful", product, HttpStatusCode.Created);
                }
                else
                {
                    return CustomResult("Product saved failed", product, HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    return CustomResult("Product not found", HttpStatusCode.NotFound);
                }
                bool isUpdated = _productManager.Update(product.Id,product);

                if (isUpdated)
                {
                    return CustomResult("Product has been updated successful", product, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("Product updated failed", product, HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpDelete]
        public IActionResult DeleteProduct(String id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return CustomResult("Product not found", HttpStatusCode.NotFound);
                }
                bool isDeleted = _productManager.Delete(id);

                if (isDeleted)
                {
                    return CustomResult("Product has been deleted successful", HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("Product deleted failed", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
