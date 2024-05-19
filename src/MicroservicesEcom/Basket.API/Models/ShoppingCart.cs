namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public ShoppingCart() { }
        public ShoppingCart(String userName)
        {
            this.UserName = userName;
        }

        public String UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }=new List<ShoppingCartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (ShoppingCartItem item in Items)
                {
                    total += item.Price;
                }
                return total;
            }
        }

    }
}
