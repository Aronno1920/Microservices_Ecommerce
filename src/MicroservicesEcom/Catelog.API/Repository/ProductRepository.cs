using Catelog.API.Context;
using Catelog.API.Interfaces.Repository;
using Catelog.API.Models;
using MongoRepo.Context;
using MongoRepo.Repository;

namespace Catelog.API.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new CatalogDbContext())
        {
        }
    }
}
