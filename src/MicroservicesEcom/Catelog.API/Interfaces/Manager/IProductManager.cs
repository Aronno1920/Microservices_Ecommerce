using Catelog.API.Models;
using MongoRepo.Interfaces.Manager;

namespace Catelog.API.Interfaces.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {
        List<Product> GetByCategory(string category);


    }
}
