using MongoRepo.Context;

namespace Catelog.API.Context
{
    public class CatalogDbContext : ApplicationDbContext
    {
        static IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",true,true).Build();

        static string connectionString = configuration.GetConnectionString("Catalog.API");
        static string databaseName = configuration.GetValue<string>("DatabaseName");

        public CatalogDbContext() : base(connectionString, databaseName)
        {

        }
    }
}
