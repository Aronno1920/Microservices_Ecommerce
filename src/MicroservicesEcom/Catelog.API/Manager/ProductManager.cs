using Catelog.API.Interfaces.Manager;
using Catelog.API.Models;
using Catelog.API.Repository;
using MongoRepo.Manager;
using MongoRepo.Repository;

namespace Catelog.API.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager() : base(new ProductRepository())
        {
        }

        public List<Product> GetByCategory(string category)
        {
            return GetAll(c => c.Category == category).ToList();
        }
    }
}
