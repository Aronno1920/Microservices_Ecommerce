using Catelog.API.Interfaces.Manager;
using Catelog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catelog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        IProductManager _productManager;
        public CatalogController(IProductManager productManager) {
            _productManager = productManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public IActionResult GetProducts() {
            var products = _productManager.GetAll();
            return Ok(products);
        }
    }
}
