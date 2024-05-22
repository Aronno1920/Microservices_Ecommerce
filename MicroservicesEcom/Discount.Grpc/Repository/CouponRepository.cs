using Dapper;
using Discount.Grpc.Models;
using Npgsql;

namespace Discount.Grpc.Repository
{
    public class CouponRepository : ICouponRepository
    {
        IConfiguration _configuration;

        public CouponRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));

            var affedRow = await connection.ExecuteAsync("INSERT INTO Coupon(productId,productName,description,amount) VALUES (@ProductId, @ProductName, @Description, @Amount)", new { ProductId = coupon.ProductId, ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
            if (affedRow > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteDiscount(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));

            var affedRow = await connection.ExecuteAsync("DELETE FROM Coupon WHERE productId=@ProductId",new { ProductId = productId});
            if (affedRow > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Coupon> GetDiscount(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE productId=@ProductId", new { ProductId = productId });
            if (coupon == null)
            {
                return new Coupon() { Amount = 0, ProductName = "No Discount" };
            }
            else
            {
                return coupon;
            }
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));

            var affedRow = await connection.ExecuteAsync("UPDATE Coupon SET productId=@ProductId,productName=@ProductName,description=@Description,amount=@Amount", new { ProductId = coupon.ProductId, ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
            if (affedRow > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
